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
        public static ProcessingPositions Default;

        public Dictionary<int, DataCarsLocation> dataCarsLocation = new Dictionary<int, DataCarsLocation>();

        public void HandleSignal(SignalSetCarPosition arg)
        {
            if (dataCarsLocation.ContainsKey(arg.postion))
            {
                dataCarsLocation[arg.postion].SetData(arg.car, arg.trafficLight, arg.trafficSign);
            }
            dataCarsLocation.Add(arg.postion, new DataCarsLocation(arg.car,arg.trafficLight,arg.trafficSign));
        }

        public void HandleSignal(SignalSetComperativePositions arg)
        {
            SetPositions();
        }

        public bool TryGetCar(int position, out Actor car)
        {
            DataCarsLocation roadSpot;
            if (dataCarsLocation.TryGetValue(position, out roadSpot))
            {
                car = roadSpot.car;
                return true;
            }
            car = null;
            return false;
        }
        public bool TryGetTrafiicSign(int position, out TrafficSign sign)
        {
            DataCarsLocation roadSpot;
            if (dataCarsLocation.TryGetValue(position, out roadSpot))
            {
                sign = roadSpot.trafficSign;
                return true;
            }
            sign = TrafficSign.Empty;
            return false;
        }
        public bool TryGetTrafficLight(int position, out TrafficLight TL)
        {
            DataCarsLocation roadSpot;
            if (dataCarsLocation.TryGetValue(position, out roadSpot))
            {
                TL = roadSpot.trafficLight;
                return true;
            }
            TL = TrafficLight.Empty;
            return false;
        }

        private void SetPositions()
        {
            int lengthOfCars = DataRoadSituation.MaxCars;
            Actor settingCar;
            Actor comperativeCar;
            for (int iSpot = 0; iSpot < lengthOfCars; iSpot++)
            {
                if (TryGetCar(iSpot, out settingCar))
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

                        if (TryGetCar(comperativeIndex, out comperativeCar))
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

