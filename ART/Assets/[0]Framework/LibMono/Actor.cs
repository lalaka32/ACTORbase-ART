/*===============================================================
Product:    Battlecruiser
Developer:  Dimitry Pixeye - pixeye@hbrew.store
Company:    Homebrew - http://hbrew.store
Date:       12/09/2017 19:06
================================================================*/

using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using Object = UnityEngine.Object;

namespace Homebrew
{
 
	public abstract class Actor : MonoCached
	{
		[HideInInspector] public int hashCode;
		[HideInInspector] public ProcessingTags tags;


		private List<Behavior> behaviours = new List<Behavior>(EngineSettings.ActorElementsCount);

		private List<ITick> ticks = new List<ITick>();
		private List<ITickLate> ticksLate = new List<ITickLate>();
		private List<ITickFixed> ticksFixed = new List<ITickFixed>();
		private Queue<Behavior> behaviorsToAdd = new Queue<Behavior>(8);
		private Dictionary<int, object> components = new Dictionary<int, object>(EngineSettings.ActorElementsCount);

		private int countTicks;
		private int countTicksLate;
		private int countTicksFixed;

		private int countBehaviors;


		protected abstract void Setup();

		protected override void OnAwake()
		{
			hashCode = GetHashCode();
			tags.SetActor(this);
			tags.Add(hashCode);
			Setup();
			StartCoroutine(_AddBehavior());
		}

		IEnumerator _AddBehavior()
		{
			yield return 0;
			var amount = behaviorsToAdd.Count;
			for (int i = 0; i < amount; i++)
			{
				var behavior = behaviorsToAdd.Dequeue();
				behavior.SetActor(this);
				behavior.Awake();


				var tick = behavior as ITick;
				var tickFixed = behavior as ITickFixed;
				var tickLate = behavior as ITickLate;

				if (tick != null)
				{
					ticks.Add(tick);
					countTicks++;
				}

				if (tickFixed != null)
				{
					ticksFixed.Add(tickFixed);
					countTicksFixed++;
				}

				if (tickLate != null)
				{
					ticksLate.Add(tickLate);
					countTicksLate++;
				}


				behaviours.Add(behavior);
				countBehaviors++;
			}
		}


		protected override void OnTimeScaleChanged()
		{
			signals.Send(new SignalTimeScaleChanged());
		}


		#region PROCESSING

		public void HandleTagsChanged()
		{
			if (Toolbox.isQuittingOrChangingScene()) return;

			ProcessingEntities.Default.Changed(this);
			for (var i = 0; i < countBehaviors; i++)
			{
				behaviours[i].OnTagsChanged();
			}
		}

		public override void Tick()
		{
			for (var i = 0; i < countTicks; i++)
			{
				ticks[i].Tick();
			}

			OnTick();
		}

		public void TickLate()
		{
			for (var i = 0; i < countTicksLate; i++)
			{
				ticksLate[i].TickLate();
			}
		}

		public void TickFixed()
		{
			for (var i = 0; i < countTicksFixed; i++)
			{
				ticksFixed[i].TickFixed();
			}
		}

		protected virtual void OnTick()
		{
		}

		#endregion

		#region PROCESSING ACTIVATION

		public override void OnEnable()
		{
			if (state.HasState(EntityState.OnHold)) return;
			if (state.HasState(EntityState.Enabled)) return;
			state &= ~EntityState.Released;
			state |= EntityState.Enabled;

			signals.Add(this);

			ProcessingUpdate.Default.Add(this);
			ProcessingEntities.Default.Add(this);

			for (var i = 0; i < countBehaviors; i++)
			{
				behaviours[i].Enable(true);
			}
		}

		public override void OnDisable()
		{
			if (Toolbox.isQuittingOrChangingScene()) return;
			if (state.HasState(EntityState.Released)) return;
			if (!state.HasState(EntityState.Enabled)) return;
			state &= ~EntityState.Enabled;

			signals.Remove(this);

			ProcessingEntities.Default.Remove(this);
			ProcessingUpdate.Default.Remove(this);

			for (var i = 0; i < countBehaviors; i++)
			{
				behaviours[i].Enable(false);
			}
		}


		protected override void OnSpawn()
		{
			for (var i = 0; i < countBehaviors; i++)
			{
				behaviours[i].Spawn(true);
			}
		}

		protected override void OnDespawn()
		{
			for (var i = 0; i < countBehaviors; i++)
			{
				behaviours[i].Spawn(false);
			}
		}

		#endregion

		#region PROCESSING ADD / REMOVE

		public void ForceAdd()
		{
			StartCoroutine(_AddBehavior());
		}

		void AddBehavior(Behavior behavior, bool enabled = true)
		{
			behaviorsToAdd.Enqueue(behavior);
			behavior.Activate(enabled);
		}


		T HandleAdd<T>(T component, bool enabled = true, Type desiredType = null)
		{
			var hash = desiredType == null ? typeof(T).GetHashCode() : desiredType.GetHashCode();
			components.Add(hash, component);

			var behavior = component as Behavior;
			if (behavior != null)
			{
				AddBehavior(behavior, enabled);
			}
			else
			{
				var setupable = component as ISetup;
				if (setupable != null) setupable.Setup(this);
				tags.Add(hash);
			}

			return component;
		}

		public void Add<T>(T component, Type desiredType = null)
		{
			HandleAdd(component, true, desiredType);
		}

		public T Add<T>(bool enabled = true, Type desiredType = null) where T : new()
		{
			var component = new T();
			return HandleAdd(component, enabled, desiredType);
		}

		public T AddForce<T>(bool enabled = true, Type desiredType = null) where T : new()
		{
			var component = new T();
			var o = HandleAdd(component, enabled, desiredType);

			return o;
		}

		public void RemoveData<T>() where T : IData
		{
			var hash = typeof(T).GetHashCode();
			object obj;
			if (components.TryGetValue(hash, out obj))
			{
				var data = obj as IData;
				data.Dispose();
				components.Remove(hash);
				tags.Remove(hash);
			}
		}

		public void RemoveBehavior<T>() where T : Behavior
		{
			var hash = typeof(T).GetHashCode();
			object obj;
			if (components.TryGetValue(hash, out obj))
			{
				countBehaviors--;
				var b = obj as Behavior;
				components.Remove(hash);
				behaviours.Remove(b);

				signals.Remove(b);

				var tickable = b as ITick;
				if (tickable != null)
				{
					ticks.Remove(tickable);
					countTicks--;
				}

				var tickableFixed = b as ITickFixed;
				if (tickableFixed != null)
				{
					ticksFixed.Remove(tickableFixed);
					countTicksFixed--;
				}

				var tickableLate = b as ITickLate;
				if (tickableLate != null)
				{
					ticksLate.Remove(tickableLate);
					countTicksLate--;
				}

				b.Dispose();
			}
		}

		#endregion

		#region PROCESSING GET

		public T Get<T>(int index = 0) where T : class
		{
			return components[index] as T;
		}


		public T Get<T>() where T : class
		{
			object obj;
			if (components.TryGetValue(typeof(T).GetHashCode(), out obj))
			{
				return (T) obj;
			}

			return typeof(T).IsSubclassOf(typeof(Object)) ? GetComponentInChildren<T>() : null;
		}

		public T Get<T>(string path = default(string)) where T : Object
		{
			if (path == string.Empty) return GetComponentInChildren<T>();
			var o = selfTransform.Find(path);
			return o == null ? default(T) : o.GetComponent<T>();
		}

		public object GetObject(Type t)
		{
			object obj;
			components.TryGetValue(t.GetHashCode(), out obj);


			if (obj == null)
				if (t == typeof(Component))
					return GetComponentInChildren(t);

			return obj;
		}

		#endregion

		#region PROCESSING SEARCH

		public bool Contains<T>()
		{
			return components.ContainsKey(typeof(T).GetHashCode());
		}

		#endregion

		#region PROCESSING DEACTIVATION

		private void OnDestroy()
		{
			countTicks = 0;
			countTicksFixed = 0;
			countTicksLate = 0;
			countBehaviors = 0;

			foreach (var value in components.Values)
			{
				var disposable = value as IDisposable;

				if (disposable == null) continue;
				disposable.Dispose();
			}

			if (!Toolbox.isQuittingOrChangingScene())
			{
				ProcessingEntities.Default.Remove(this);
				ProcessingUpdate.Default.Remove(this);
			}

			ticks.Clear();
			ticksFixed.Clear();
			ticksLate.Clear();

			behaviours.Clear();
			components.Clear();
		}

		#endregion
	}
}
