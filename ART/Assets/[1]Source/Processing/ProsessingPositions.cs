using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class ProsessingPositions : ProcessingBase,IReceive<SignalCarSpawn>, IMustBeWiped
    {
        [GroupBy(Tag.Cross)]
        Group cross;

        public void HandleSignal(SignalCarSpawn arg)
        {
            SetPositions();
        }

        private void SetPositions()
        {
            for (int iCross = 0; iCross < cross.length; iCross++)
            {
                if (cross.actors[iCross].Get<DataCarsLocation>() != null)
                {
                    int lengthOfCars = Toolbox.Get<DataGameSession>().dataRoadSituation.CountOfCars;
                    for (int iSpot = 0; iSpot < lengthOfCars; iSpot++)
                    {
                        Actor settingCar = cross.actors[iCross].Get<DataCarsLocation>().positions[iSpot];
                        if (settingCar != null)
                        {
                            int comperativePosition = iSpot;
                            for (int jSpot = 1; jSpot < lengthOfCars; jSpot++)
                            {
                                if ((jSpot + iSpot) > lengthOfCars-1)
                                {
                                    comperativePosition = jSpot + iSpot - lengthOfCars;
                                }
                                else
                                {
                                    comperativePosition = jSpot + iSpot;
                                }
                                
                                Actor comperativeActor = cross.actors[iCross].Get<DataCarsLocation>().positions[comperativePosition];
                                if (comperativeActor!=null)
                                {
                                    settingCar.Get<DataComperativeCars>().comperative.Add(comperativePosition, comperativeActor);
                                   // Debug.Log("comperativePosition"+ comperativePosition + "---------------- comperativeActor" + comperativeActor);
                                }
                                
                            }
                        }
                    }
                }
            }
        }
    }
}
