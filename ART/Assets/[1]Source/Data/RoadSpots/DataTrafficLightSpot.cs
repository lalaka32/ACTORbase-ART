using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    [Serializable]
    public class DataTrafficLightSpot : IData
    {
        public ActorTag trafficLightSpot;
        public void Dispose()
        {
            trafficLightSpot = null;
        }
    }
}
