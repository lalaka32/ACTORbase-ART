using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    class ProcessingQuiz : ProcessingBase, IMustBeWipedOut, IReceive<SignalNextRound>
    {
        public void HandleSignal(SignalNextRound arg)
        {
            Toolbox.Get<DataGameSession>().NumberOfQuestion++;
            
        }
    }
}
