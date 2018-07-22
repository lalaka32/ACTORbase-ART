﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    // От BluePrint а пока отказался с целью упрощения
    class BehaviorAnimation : ActorBehavior, IReceive<SignalPlayCarAnimation>
    {
        [Bind] DataCarTurnAnimations dataCarTurnAnimations;
        [Bind] DataDirection dataDirection;

        public void HandleSignal(SignalPlayCarAnimation arg)
        {
            dataCarTurnAnimations.animatorCarTurn.SetInteger("Direction",(int)dataDirection.direction);
        }
    }
}