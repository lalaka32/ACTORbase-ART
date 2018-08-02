using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enums;
using UnityEngine;
using Homebrew;

namespace BeeFly
{
    class ForwardQvalent : IDirectionable
    {
        public void SetPriority(DataComperativeCars comperative, Actor settingCar)
        {
            Situation observeCar;
            
            if (comperative.comperative.TryGetValue(ComperativePos.Right, out observeCar))
            {
                settingCar.Get<DataPriority>().priority++;//+tested[0]

                if (observeCar.direction.direction == Direction.Forward)
                {
                    if (comperative.comperative.TryGetValue(ComperativePos.Front, out observeCar))
                    {
                        settingCar.Get<DataPriority>().priority++;//+tested[1]
                    }
                }
                else if (observeCar.direction.direction == Direction.Left)
                {
                    if (comperative.comperative.TryGetValue(ComperativePos.Front, out observeCar))
                    {
                        settingCar.Get<DataPriority>().priority++;//+tested[2]
                    }
                    else if (comperative.comperative.TryGetValue(ComperativePos.Left, out observeCar))
                    {
                        if (observeCar.direction.direction == Direction.Right)
                        {
                            settingCar.Get<DataPriority>().priority++;//+tested[3]
                        }
                    }
                }
            }
        }
    }

}
