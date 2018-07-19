using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    struct SignalCarSpawn
    {
        public int postion;
        public ActorCar car;

        public SignalCarSpawn(int postion, ActorCar car)
        {
            this.postion = postion;
            this.car = car;
        }
    }
}
