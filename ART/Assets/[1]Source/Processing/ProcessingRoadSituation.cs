using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    class ProcessingRoadSituation : ProcessingBase, IReceive<SignalTougleColor>
    {
        public void HandleSignal(SignalTougleColor arg)
        {
            ProcessingSignals.Default.Send(new SignalSwitchColor());
        }
    }
}
