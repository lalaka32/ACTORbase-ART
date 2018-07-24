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
            Actor observeCar;

            if (comperative.comperative.TryGetValue(ComperativePos.Right, out observeCar))
            {
                if (observeCar.Get<DataDirection>().direction == Direction.Forward)
                {
                    settingCar.Get<DataPriority>().priority++;

                    if (comperative.comperative.TryGetValue(ComperativePos.Front, out observeCar))
                    {
                        settingCar.Get<DataPriority>().priority++;
                    }
                }
                else if (observeCar.Get<DataDirection>().direction == Direction.Left)
                {
                    settingCar.Get<DataPriority>().priority++;
                    if (comperative.comperative.TryGetValue(ComperativePos.Front, out observeCar))
                    {
                        settingCar.Get<DataPriority>().priority++;
                    }
                    else if (comperative.comperative.TryGetValue(ComperativePos.Left, out observeCar))
                    {
                        if (observeCar.Get<DataDirection>().direction == Direction.Right)
                        {
                            settingCar.Get<DataPriority>().priority++;
                        }
                    }
                }

                else if (observeCar.Get<DataDirection>().direction == Direction.Right)
                {
                    settingCar.Get<DataPriority>().priority++;
                }
            }
        }
    }

}
