using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class ProcessingPriority : ProcessingBase, IReceive<SignalSetPriority>, IMustBeWipedOut
    {
        [GroupBy(Tag.Car)]
        Group cars;

        public void HandleSignal(SignalSetPriority arg)
        {
            foreach (var car in cars.actors)
            {
                car.signals.Send(new SignalSetPriority());
            }
        }
    }
}
