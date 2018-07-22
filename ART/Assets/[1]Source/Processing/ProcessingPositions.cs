using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class ProcessingPositions : ProcessingBase, IReceive<SignalSetComperativePositions>, IReceive<SignalSetCarPosition>, IMustBeWipedOut
    {
        public DataCarsLocation dataCarsLocation = new DataCarsLocation();

        [GroupBy(Tag.Cross)]
        Group cross;

        public void HandleSignal(SignalSetComperativePositions arg)
        {
            SetPositions();
        }

        public void HandleSignal(SignalSetCarPosition arg)
        {
            dataCarsLocation.positions.Add(arg.postion, arg.car);
        }

        private void SetPositions()
        {
            int lengthOfCars = DataRoadSituation.MaxCars;
            Actor settingCar;
            Actor comperativeCar;
            for (int iSpot = 0; iSpot < lengthOfCars; iSpot++)
            {
                if (dataCarsLocation.positions.TryGetValue(iSpot, out settingCar))
                {
                    int comperativePosition = -1;
                    for (int jSpot = 1; jSpot < lengthOfCars; jSpot++)
                    {
                        comperativePosition++;
                        int comperativeIndex = iSpot + jSpot;

                        if (comperativeIndex > lengthOfCars - 1)
                        {
                            comperativeIndex -= lengthOfCars;
                        }

                        if (dataCarsLocation.positions.TryGetValue(comperativeIndex, out comperativeCar))
                        {
                            settingCar.Get<DataComperativeCars>().comperative.Add(comperativePosition, comperativeCar);
                            //Debug.Log("comperativePosition" + comperativePosition + "---------------- comperativeActor" + comperativeCar.name);
                        }
                    }
                }
            }
        }
        enum ComperativeLocation
        {
            Right, Front, Left
        }
    }
}

