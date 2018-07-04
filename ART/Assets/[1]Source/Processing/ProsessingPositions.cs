using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class ProsessingPositions : ProcessingBase, IMustBeWiped
    {
        [GroupBy(Tag.Cross)]
        Group cross;

        public ProsessingPositions()
        {
            Homebrew.Timer.Add(0.1f, () => SetPositions());
        }

        private void SetPositions()
        {
            for (int iCross = 0; iCross < cross.length; iCross++)
            {
                if (cross.actors[iCross].Get<DataCarsLocation>() != null)
                {
                    int lengthOfCarSpots = Toolbox.Get<DataGameSession>().dataRoadSituation.CountOfCars;
                    for (int iSpot = 0; iSpot < lengthOfCarSpots; iSpot++)
                    {
                        Actor settingCar = cross.actors[iCross].Get<DataCarsLocation>().positions[iSpot];
                        if (settingCar != null)
                        {
                            int comperativePosition = iSpot;
                            for (int jSpot = 1; jSpot < lengthOfCarSpots; jSpot++)
                            {
                                if ((jSpot + iSpot) > lengthOfCarSpots-1)
                                {
                                    comperativePosition = jSpot + iSpot - lengthOfCarSpots;
                                }
                                else
                                {
                                    comperativePosition = jSpot + iSpot;
                                }
                                Actor comperativeActor = cross.actors[iCross].Get<DataCarsLocation>().positions[comperativePosition];
                                settingCar.Get<DataComperativeCars>().comperative.Add(comperativePosition, comperativeActor);
                            }
                        }
                    }
                }
            }
        }
    }
}
