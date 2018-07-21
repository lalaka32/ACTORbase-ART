using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Homebrew;

namespace BeeFly
{
    class BehaviourTurnOnLight : ActorBehavior, IReceive<SignalSetLights>
    {
        [Bind] DataTurnerPositions dataTurnerPositions;
        [Bind] DataDirection dataDirection;

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
                    Toolbox.Get<FactoryRoad>().Spawn(front.position, front.rotation, Tag.Turner,actor.selfTransform.Find("AbstractBody/PointMain"));
                    Toolbox.Get<FactoryRoad>().Spawn(back.position, back.rotation, Tag.Turner, actor.selfTransform.Find("AbstractBody/PointMain"));
                    break;
                case Direction.Right:
                    front = dataTurnerPositions.frontRight;
                    back = dataTurnerPositions.backRight;
                    Toolbox.Get<FactoryRoad>().Spawn(front.position, front.rotation, Tag.Turner, actor.selfTransform.Find("AbstractBody/PointMain"));
                    Toolbox.Get<FactoryRoad>().Spawn(back.position, back.rotation, Tag.Turner, actor.selfTransform.Find("AbstractBody/PointMain"));
                    break;
            }
        }
    }
}
