using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    [Serializable]
    class DataSignSpot : IData
    {
        public ActorTag signSpot;
        public void Dispose()
        {
            signSpot = null;
        }
    }
}
