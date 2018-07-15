using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{ 
    class ActorCar : Actor
    {
        //public DataBlueprint blueprint;

        [FoldoutGroup("Setup")] public DataPriority priority;
        [FoldoutGroup("Setup")] public DataDirection direction;

        public DataComperativeCars comperativeCars;

        protected override void Setup()
        {
            //Add(blueprint);

            Add(priority);
            Add(direction);
            Add(comperativeCars);

            //Add<BehaviourDeath>();
            Add<BehaviorPriority>();
            //Add<BehaviourRecieveGlobalSignal>();
            Add<BehaviourDebugOut>();
            
            tags.Add(Tag.Car);
        }
        protected override void OnBeforeDestroy()
        {
            OnDisable();
        }
    }



    public enum Direction
    {
        Right, Forward, Left
    }
}
