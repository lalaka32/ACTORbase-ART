using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class BehabiorStateDeth : BaseStateMachineBehavior
    {
        protected override void OnSetup() {}

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            actor.HandleDestroyGO();
        }
    }
}