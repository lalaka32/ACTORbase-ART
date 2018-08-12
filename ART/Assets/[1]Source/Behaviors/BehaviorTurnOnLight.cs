using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Homebrew;

namespace BeeFly
{
    class BehaviorTurnOnLight : ActorBehavior, IReceive<SignalSetLights>
    {
        [Bind] DataTurnerPositions dataTurnerPositions;
        [Bind] DataDirection dataDirection;
        public List<Transform> Turners { get; private set; } = new List<Transform>();


        public void HandleSignal(SignalSetLights arg)
        {
            SetTurner();
        }
        void SetTurner()
        {
            Transform front;
            Transform back;
            switch (dataDirection.direction)
            {
                case Direction.Left:
                    front = dataTurnerPositions.frontLeft;
                    back = dataTurnerPositions.backLeft;
                    Turners.Add(Toolbox.Get<FactoryRoad>().Spawn(front.position, front.rotation, Tag.Turner,actor.selfTransform.Find("AbstractBody")));
                    Turners.Add(Toolbox.Get<FactoryRoad>().Spawn(back.position, back.rotation, Tag.Turner, actor.selfTransform.Find("AbstractBody")));
                    break;
                case Direction.Right:
                    front = dataTurnerPositions.frontRight;
                    back = dataTurnerPositions.backRight;
                    Turners.Add(Toolbox.Get<FactoryRoad>().Spawn(front.position, front.rotation, Tag.Turner, actor.selfTransform.Find("AbstractBody")));
                    Turners.Add(Toolbox.Get<FactoryRoad>().Spawn(back.position, back.rotation, Tag.Turner, actor.selfTransform.Find("AbstractBody")));
                    break;
            }
        }
    }
}
