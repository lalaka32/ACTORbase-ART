using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class BehaviourStateMoving : BaseStateMachineBehavior ,IReceive<SignalPlayCarAnimation>, IReceive<SignalTurnOffLight>
    {
        protected override void OnSetup()
        {
            actor.signals.Add(this);
        }
        public override void End()
        {
            actor.signals.Remove(this);
        }
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
