using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Homebrew;

namespace BeeFly
{
    [Serializable]
    public class DataSpotTrafficSign : IData
    {
        public List<ActorTag> Positions;

        public void Dispose(){}
    }
}
