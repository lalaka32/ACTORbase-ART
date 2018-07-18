using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    class ProcessingDespawn : ProcessingBase, IReceive<SignalDespawn>, IMustBeWipedOut
    {
        [GroupBy(Tag.Cross)]
        Group Cross;

        public void HandleSignal(SignalDespawn arg)
        {
            ProcessingSignals.Default.Send(new SignalKillCars());
            Cross.actors[0].Get<DataCarsLocation>().positions.Clear();
        }
    }
}
