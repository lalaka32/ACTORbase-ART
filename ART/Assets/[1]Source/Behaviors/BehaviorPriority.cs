﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class BehaviorPriority : ActorBehavior, IReceive<SignalSetPriority>
    {
        //есть идея не вписывать разделять наши правили а просто добавлять доп правила при
        //условиях типа есть TL есть Sign

        [Bind] DataPriority priority;
        [Bind] DataComperativeCars comperative;
        [Bind] DataDirection direction;

        public void HandleSignal(SignalSetPriority arg)
        {
            SetPriority();
        }

        public void SetPriority()
        {
            IDirectionable carDir;
            if (true)
            {
                switch (direction.direction)
                {
                    case Direction.Forward:
                        carDir = new ForwardQvalent();
                        carDir.SetPriority(comperative, actor);
                        break;
                    case Direction.Right:
                        carDir = new DirectionRight();
                        carDir.SetPriority(comperative, actor);
                        break;
                    case Direction.Left:
                        carDir = new LeftDirectionQvalent();
                        carDir.SetPriority(comperative, actor);
                        break;
                }
                
                Debug.Log(priority.priority+"POs"+actor.name);
            }
            else if (ToolBox.Get<TrafficLightManager>().PosTL != null)
            {
                switch (direction.direction)
                {
                    case Direction.Forward:
                        carDir = new PriorityTL();
                        carDir.SetPriority(comperative, this.actor);
                        break;
                    case Direction.Right:
                        carDir = new PriorityTL();
                        carDir.SetPriority(comperative, this.actor);
                        break;
                    case Direction.Left:
                        carDir = new LeftTL();
                        carDir.SetPriority(comperative, this.actor);
                        break;
                }
            }
            else if (ToolBox.Get<SignManager>().TS != null)
            {
                switch (direction.direction)
                {
                    case Direction.Forward:
                        carDir = new Unqvalent();
                        carDir.SetPriority(comperative, this.actor);
                        break;
                    case Direction.Right:
                        carDir = new Unqvalent();
                        carDir.SetPriority(comperative, this.actor);
                        break;
                    case Direction.Left:
                        carDir = new LeftUnqvalent();
                        carDir.SetPriority(comperative, this.actor);
                        break;
                }
            }
        }

    }

}
