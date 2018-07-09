using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class ActorTL : Actor
    {
        protected override void Setup()
        {
            if (Toolbox.Get<DataGameSession>().dataRoadSituation.TrafficLight)
            {
                GetComponent<Animator>().SetBool("isOn", true);
            }
        }
    }
}
