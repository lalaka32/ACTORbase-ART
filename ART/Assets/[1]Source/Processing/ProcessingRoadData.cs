using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class ProcessingRoadData : ProcessingBase, IMustBeWipedOut, IReceive<SignalNextRound>
    {
        public ProcessingRoadData()
        {
            Toolbox.Get<DataGameSession>().SetRoadData();
        }
        public void HandleSignal(SignalNextRound arg)
        {
            Toolbox.Get<DataGameSession>().SetRoadData();
        }
    }
}
