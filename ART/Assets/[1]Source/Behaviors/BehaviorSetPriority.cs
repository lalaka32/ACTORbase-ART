using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    class BehaviorPriority : Behavior,IRecieve<SignalCarSpawn>
    {
        //есть идея не вписывать разделять наши правили а просто добавлять доп правила при
        //условиях типа есть TL есть Sign

        [Bind] DataPriority priority;
        [Bind] DataComperativeCars comperative;
        [Bind] DataDirection direction;

        public void HandleSignal(SignalCarSpawn arg)
        {
            IDirectionable carDir;
            if (ToolBox.Get<TrafficLightManager>().PosTL == null && ToolBox.Get<SignManager>().TS == null)
            {
                switch (direction.direction)
                {
                    case Direction.Forward:
                        carDir = new ForwardQvalent();
                        carDir.SetPriority(comperative, this.actor);
                        break;
                    case Direction.Right:
                        carDir = new DirectionRight();
                        carDir.SetPriority(comperative, this.actor);
                        break;
                    case Direction.Left:
                        carDir = new LeftDirectionQvalent();
                        carDir.SetPriority(comperative, this.actor);
                        break;
                }
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
