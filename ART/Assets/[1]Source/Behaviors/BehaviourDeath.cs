using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class BehaviourDeath : ActorBehavior, IReceive<SignalKillCar>
    {
        public void HandleSignal(SignalKillCar arg)
        {
            if (!actor.tags.Contain(Tag.Dead))
            {
                actor.HandleDestroyGO();
            }
            actor.tags.Add(Tag.Dead);
        }
    }
}
