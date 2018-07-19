using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class ProcessingPositions : ProcessingBase, IReceive<SignalSpawnEnded>, IReceive<SignalCarSpawn>, IMustBeWipedOut
    {
        public DataCarsLocation dataCarsLocation = new DataCarsLocation();

        [GroupBy(Tag.Cross)]
        Group cross;

        public void HandleSignal(SignalSpawnEnded arg)
        {
            SetPositions();
        }

        public void HandleSignal(SignalCarSpawn arg)
        {
            dataCarsLocation.positions.Add(arg.postion, arg.car);
        }

        private void SetPositions()
        {
            int lengthOfCars = Toolbox.Get<DataGameSession>().dataRoadSituation.CountOfCars;
            for (int iSpot = 0; iSpot < lengthOfCars; iSpot++)
            {
                Actor settingCar = dataCarsLocation.positions[iSpot];
                if (settingCar != null)
                {
                    int comperativePosition = iSpot;
                    for (int jSpot = 1; jSpot < lengthOfCars; jSpot++)
                    {
                        if ((jSpot + iSpot) > lengthOfCars - 1)
                        {
                            comperativePosition = jSpot + iSpot - lengthOfCars;
                        }
                        else
                        {
                            comperativePosition = jSpot + iSpot;
                        }

                        Actor comperativeActor = dataCarsLocation.positions[comperativePosition];
                        if (comperativeActor != null)
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

