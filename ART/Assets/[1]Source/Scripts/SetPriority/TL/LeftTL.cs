using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enums;
using UnityEngine;
using Homebrew;

namespace BeeFly
{
    class LeftTL : PriorityTL
{
    public override void SetPriority(DataComperativeCars comperative, Actor settingCar)
    {
<<<<<<< HEAD

        Car observeCar;
        base.SetPriority(comperative, settingCar);
=======
        
        //Car observeCar;
        //base.SetPriority(comperative, settingCar);
>>>>>>> 534b94e84f74c3fb2bcc6a54500ea754df407593

        //if (comperative.TryGetValue(ComperativeLocation.Front, out observeCar))
        //{
        //    if (observeCar.Direction != Direction.Left)
        //    {
        //        settingCar.priority++;
        //    }
        //}
    }
}

}

