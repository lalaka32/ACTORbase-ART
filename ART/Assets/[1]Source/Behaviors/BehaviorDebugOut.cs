using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;
using FastDeb;

namespace BeeFly
{
    class BehaviorDebugOut : ActorBehavior, IReceive<SignalKillCar>
    {
        [Bind] DataPriority priority;

        public void HandleSignal(SignalKillCar arg)
        {
            
        }
    }
}
