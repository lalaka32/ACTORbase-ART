using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class ProcessingRoadData : ProcessingBase, IMustBeWipedOut, IReceive<SignalSetRoadData>
    {
        public void HandleSignal(SignalSetRoadData arg)
        {
            Toolbox.Get<DataArtSession>().SetRoadData();
        }
    }
}
