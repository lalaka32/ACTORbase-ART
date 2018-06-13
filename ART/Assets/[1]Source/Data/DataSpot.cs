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
    class DataSpot : IData
    {
        [SerializeField]
        ActorTag position;

        public void Dispose(){}
    }
}
