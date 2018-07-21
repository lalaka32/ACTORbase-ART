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
            Actor observeCar;

            if (comperative.comperative.TryGetValue(ComperativePos.Right, out observeCar))
            {
                settingCar.Get<DataPriority>().priority++;
                if (observeCar.Get<DataDirection>().direction == Direction.Forward)
                {
                    if (comperative.comperative.TryGetValue(ComperativePos.Front, out observeCar))
                    {
                        settingCar.Get<DataPriority>().priority++;
                    }
                }
                else if (observeCar.Get<DataDirection>().direction == Direction.Left)
                {
                    if (comperative.comperative.TryGetValue(ComperativePos.Front, out observeCar))
                    {
                        settingCar.Get<DataPriority>().priority++;
                    }
                    else
                    {
                        if (comperative.comperative.TryGetValue(ComperativePos.Left, out observeCar))
                        {
                            if (observeCar.Get<DataDirection>().direction == Direction.Right)
                            {
                                settingCar.Get<DataPriority>().priority++;
                            }
                        }
                    }
                }
            }
            else if (comperative.comperative.TryGetValue(ComperativePos.Front, out observeCar))
            {
                if (observeCar.Get<DataDirection>().direction == Direction.Right)
                {
                    settingCar.Get<DataPriority>().priority++;
                }
                else if (observeCar.Get<DataDirection>().direction == Direction.Forward)
                {
                    if (!comperative.comperative.TryGetValue(ComperativePos.Left, out observeCar))
                    {
                        settingCar.Get<DataPriority>().priority++;
                    }
                }
            }
            
        }
    }
}
