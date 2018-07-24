using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    [Serializable]
    public class DataCarSpot : IData
    {
        public ActorSpawnSpotCar carSpot;

        public void Dispose()
        {
            carSpot = null;
        }
    }
}
