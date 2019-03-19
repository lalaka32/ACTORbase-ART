using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class BehaviourStateMoving : ActorBehavior,IReceive<SignalPlayCarAnimation>, IReceive<SignalTurnOffLight>
    {

        public void HandleSignal(SignalPlayCarAnimation arg)
        {
            if (!actor.tags.Contain(Tag.Dead))
            {
                actor.Get<DataCarTurnAnimations>().animatorCarTurn.SetInteger("Direction", actor.Get<DataDirection>().direction);
            }
        }

        public void HandleSignal(SignalTurnOffLight arg)
        {
            List<Transform> Turners = actor.Get<BehaviorTurnOnLight>().Turners;

            foreach (var turner in Turners)
            {
                turner.GetComponent<Animator>().SetBool("Isturneroff", true);
            }
        }
    }
}
