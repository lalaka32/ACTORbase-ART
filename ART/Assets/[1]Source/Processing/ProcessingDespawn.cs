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
        [GroupBy(Tag.Car)]
        Group cars;

        public void HandleSignal(SignalDespawn arg)
        {
            foreach (var car in cars.actors)
            {
                car.signals.Send(new SignalKillCar());
            }
            Toolbox.Get<ProcessingPositions>().dataCarsLocation.positions.Clear();
        }
    }
}
