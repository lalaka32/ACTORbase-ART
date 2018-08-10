using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enums;
using Homebrew;

namespace BeeFly
{
    class Unqvalent : IDirectionable
    {
        public virtual void SetPriority(DataComperativeCars comperative, Actor settingCar)
        {
            //TrafficSign trafficSignal = ToolBox.Get<SignManager>().TS[settingCar.Position];

            //Actor observeCarLeft;
            //Actor observeCarRight;

            //if (trafficSignal == TrafficSign.Secondary)
            //{
            //    if (comperative.ContainsKey(ComperativeLocation.Left) || comperative.ContainsKey(ComperativeLocation.Right))
            //    {
            //        settingCar.priority++;[0]
            //    }

            //    if (comperative.TryGetValue(ComperativeLocation.Left, out observeCarLeft) && comperative.TryGetValue(ComperativeLocation.Right, out observeCarRight))
            //    {
            //        if (observeCarLeft.Direction == Direction.Left && observeCarRight.Direction != Direction.Left)
            //        {
            //            settingCar.priority++;[1]
            //        }
            //        else if (observeCarRight.Direction == Direction.Left && observeCarLeft.Direction != Direction.Left)
            //        {
            //            settingCar.priority++;[2]
            //        }

            //    }

            //}
        }
    }
}
