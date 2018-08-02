using System.Collections.Generic;
using Enums;
using UnityEngine;
using Homebrew;

namespace BeeFly
{
    class LeftDirectionQvalent : IDirectionable
    {
        public void SetPriority(DataComperativeCars comperative, Actor settingCar)
        {
            Situation observeCar;

            if (comperative.comperative.TryGetValue(ComperativePos.Right, out observeCar))
            {
                settingCar.Get<DataPriority>().priority++;//+[0]
                if (observeCar.direction.direction == Direction.Forward)
                {
                    if (comperative.comperative.TryGetValue(ComperativePos.Front, out observeCar))
                    {
                        settingCar.Get<DataPriority>().priority++;//+[1]
                    }
                }
                else if (observeCar.direction.direction == Direction.Left)
                {
                    if (comperative.comperative.TryGetValue(ComperativePos.Front, out observeCar))
                    {
                        settingCar.Get<DataPriority>().priority++;//+[2]
                    }
                    else
                    {
                        if (comperative.comperative.TryGetValue(ComperativePos.Left, out observeCar))
                        {
                            if (observeCar.direction.direction == Direction.Right)
                            {
                                settingCar.Get<DataPriority>().priority++;//+[3]
                            }
                        }
                    }
                }
            }
            else if (comperative.comperative.TryGetValue(ComperativePos.Front, out observeCar))
            {
                if (observeCar.direction.direction == Direction.Right)
                {
                    settingCar.Get<DataPriority>().priority++;//+[4]
                }
                else if (observeCar.direction.direction == Direction.Forward)
                {
                    if (!comperative.comperative.TryGetValue(ComperativePos.Left, out observeCar))
                    {
                        settingCar.Get<DataPriority>().priority++;//+[5]
                    }
                }
            }
            
        }
    }
}
