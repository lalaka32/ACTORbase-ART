using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    public struct SignalTLSetup
    {
        public int trafficLight;
        public int position;

        public SignalTLSetup( int trafficLight, int position)
        {
            this.trafficLight = trafficLight;
            this.position = position;
        }
    }
}
