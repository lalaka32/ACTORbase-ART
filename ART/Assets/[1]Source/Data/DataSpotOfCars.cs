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
    public class DataSpotOfCars : IData
    {
        public List<ActorTag> Positions;

        public void Dispose() { }
    }
}
