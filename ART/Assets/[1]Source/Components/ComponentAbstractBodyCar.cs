using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class ComponentAbstractBodyCar : MonoCached
    {
        public ActorCar car;
        public void OffTurner()
        {
            car.signals.Send(new SignalTurnOffLight());
        }
    }
}
