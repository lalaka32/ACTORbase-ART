using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    struct SignalSetCarPosition
    {
        public int postion;
        public ActorCar car;

        public SignalSetCarPosition(int postion, ActorCar car)
        {
            this.postion = postion;
            this.car = car;
        }
    }
}
