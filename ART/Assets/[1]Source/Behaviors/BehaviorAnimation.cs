using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    // От BluePrint а пока отказался с целью упрощения
    class BehaviorAnimation : ActorBehavior, IReceive<SignalPlayCarAnimation>, IReceive<SignalTurnOffLight>
    {
        [Bind] DataCarTurnAnimations dataCarTurnAnimations;
        [Bind] DataDirection dataDirection;

        public void HandleSignal(SignalPlayCarAnimation arg)
        {
            dataCarTurnAnimations.animatorCarTurn.SetInteger("Direction",dataDirection.direction);
        }
        public void HandleSignal(SignalTurnOffLight arg)
        {
            List<Transform> Turners = actor.Get<BehaviorTurnOnLight>().Turners;

            foreach (var turner in Turners)
            {
                turner.GetComponent<Animator>().SetBool("Isturneroff", true);
            }
            //actor.selfTransform.Find("AbstractBody/PointMain/turner(Clone)").GetComponent<Animator>().SetBool("Isturneroff", true);
        }

    }
}
