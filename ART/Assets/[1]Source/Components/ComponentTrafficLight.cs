using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class ComponentTrafficLight : MonoCached , IReceive<SignalSetColor>
    {
        Light light1;
        Light light2;

        public void HandleSignal(SignalSetColor arg)
        {
            light1.color = arg.color;
            light2.color = arg.color;
        }
        public void HandleSignal()
        {

        }
        protected override void HandleEnable()
        {
            ProcessingSignals.Default.Add(this);
            ProcessingDespawn.Default.Add(this);
            light1 = transform.Find("turner").GetComponent<Light>();
            light2 = transform.Find("turner (1)").GetComponent<Light>();
        }
    }
}
