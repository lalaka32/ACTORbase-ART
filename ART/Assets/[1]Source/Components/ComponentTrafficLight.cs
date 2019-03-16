using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    public class ComponentTrafficLight : MonoCached , IReceive<SignalTLSetup>,IReceive<SignalTougleColor>
    {
        Animator aminator;

        public int trafficLight;
        public int position;
        
        public void HandleSignal(SignalTLSetup arg)
        {
            trafficLight = arg.trafficLight;
            position = arg.position;
            aminator.SetInteger("Traffic Light", trafficLight);
        }

        public void HandleSignal(SignalTougleColor arg)
        {
            TougleColor();
            Toolbox.Get<DataArtSession>().GetSituation(position).trafficLight = trafficLight;
        }
        
        protected override void HandleEnable()
        {
            ProcessingSignals.Default.Add(this);
            ProcessingDespawn.Default.Add(this);
            aminator = transform.GetComponent<Animator>();
        }
        public void TougleColor()
        {
            if (trafficLight == TrafficLight.Green)
            {
                trafficLight = TrafficLight.Red;
            }
            else if(trafficLight == TrafficLight.Red)
            {
                trafficLight = TrafficLight.Green;
            }
            HandleSetColor(trafficLight);
        }

        void HandleSetColor(int color)
        {
            aminator.SetInteger("TougleColor", color);
        }
    }
}
