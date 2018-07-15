using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class BehaviourDeath : Behavior, IReceiveGlobal<SignalKillCars>
    {
        public void HandleSignal(SignalKillCars arg)
        {
            actor.tags.Add(Tag.Dead);

            actor.HandleDestroyGO();
        }
    }
}
