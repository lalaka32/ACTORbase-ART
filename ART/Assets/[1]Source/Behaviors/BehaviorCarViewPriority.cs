using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;
using TMPro;

namespace BeeFly
{
    
    class BehaviorCarViewPriority : ActorBehavior, ITick
    {
        [Bind] DataPriority priority;
        public void Tick()
        {
            actor.selfTransform.Find("AbstractBody/Body/Priority").GetComponent<TextMeshPro>().text = Convert.ToString(priority.priority);
        }
    }
}
