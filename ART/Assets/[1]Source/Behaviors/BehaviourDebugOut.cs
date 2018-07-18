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
    class BehaviourDebugOut : Behavior, IReceive<SignalDebugOut>
    {
        [Bind] DataPriority priority;

        public void HandleSignal(SignalDebugOut arg)
        {
            
        }
    }
}
