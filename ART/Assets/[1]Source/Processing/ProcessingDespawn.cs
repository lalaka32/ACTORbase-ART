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
        public static ProcessingDespawn Default;

        [GroupBy(Tag.Car)]
        Group cars;

        List<MonoCached> itemsToKill = new List<MonoCached>();

        public void Add(MonoCached monoCached)
        {
            itemsToKill.Add(monoCached);
        }
        
        public void killALL()
        {
            foreach (var item in itemsToKill)
            {
                item.HandleDestroyGO();
            }
        }

        public void HandleSignal(SignalDespawn arg)
        {
            foreach (var car in cars.actors)
            {
                car.signals.Send(new SignalKillCar());
            }
            ProcessingPositions.Default.dataCarsLocation.Clear();
        }
        void killGroup(List<Actor> group)
        {
            foreach (var item in group)
            {
                item.HandleDestroyGO();
            }
        }
    }
}
