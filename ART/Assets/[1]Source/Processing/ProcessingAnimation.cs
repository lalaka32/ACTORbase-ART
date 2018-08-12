using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class ProcessingAnimation : ProcessingBase, IMustBeWipedOut, IReceive<SignalPlayCarAnimation>
    {
        [GroupBy(Tag.Car)]
        Group cars;
        //Пока не работет GlobalRecive на поведениях
        public void HandleSignal(SignalPlayCarAnimation arg)
        {
            foreach (var item in cars.actors)
            {
                item.signals.Send(new SignalPlayCarAnimation());
            }
            //int maxPriority = 0;
            //for (int iCar = 0; iCar < cars.length; iCar++)
            //{
            //    if (cars.actors[iCar].Get<DataPriority>().priority> maxPriority)
            //    {
            //        maxPriority = cars.actors[iCar].Get<DataPriority>().priority;
            //    }
            //}
            //for (int iPriority = 0; iPriority <= maxPriority; iPriority++)
            //{
            //    for (int iCar = 0; iCar < cars.length; iCar++)
            //    {
            //        if (cars.actors[iCar].Get<DataPriority>().priority == iPriority)
            //        {
            //             cars.actors[iPriority].signals.Send(new SignalPlayCarAnimation());
            //        }
            //    }
                
            //}
        }
        
    }
}
