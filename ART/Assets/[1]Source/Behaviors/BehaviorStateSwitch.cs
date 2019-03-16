using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class BehaviorStateSwitch : BaseStateMachineBehavior
    {
        protected override void OnSetup()
        {
            actor.signals.Add(this);
        }
        public override void End()
        {
            actor.signals.Remove(this);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            ProcessingSignals.Default.Send(new SignalSwitchFinished());
        }
    }
}
