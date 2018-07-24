using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class ComponentTrafficLight : MonoCached , IReceive<SIgnalSetGreen>
    {
        Animator animator;

        public void HandleSignal(SIgnalSetGreen arg)
        {
            animator.SetInteger("SetColor",1);
        }
        protected override void HandleEnable()
        {
            ProcessingSignals.Default.Add(this);
            ProcessingDespawn.Default.Add(this);
            //animator = GetComponentInChildren<Animator>();
        }
    }
}
