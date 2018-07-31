using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class ProcessingPositions : ProcessingBase, IReceive<SignalSetComperativePositions>,  IReceive<SignalSetSituations>, IMustBeWipedOut
    {
        public static ProcessingPositions Default;

        public Dictionary<int, Situation> dataCarsLocation = new Dictionary<int, Situation>();

        public void HandleSignal(SignalSetComperativePositions arg)
        {
            SetComperativePositions();
        }

        public void HandleSignal(SignalSetSituations arg)
        {
            foreach (var item in arg.situations)
            {
                AddSituation(item);
            }
        }
        public Situation AddSituation(Situation arg)
        {
            Situation situation;

            if (dataCarsLocation.TryGetValue(arg.position, out situation))
            {
                situation = arg;
            }
            else
            {
                dataCarsLocation.Add(arg.position, arg);
            }
            return arg;
        }

        #region TryGet

        public bool TryGetCar(int position, out ActorCar car)
        {
            Situation roadSpot;
            if (dataCarsLocation.TryGetValue(position, out roadSpot))
            {
                car = roadSpot.actorCar;
                if (car != null)
                {
                    return true;
                }
            }
            car = null;
            return false;
        }

        public bool TryGetTrafiicSign(int position, out TrafficSign sign)
        {
            Situation roadSpot;
            if (dataCarsLocation.TryGetValue(position, out roadSpot))
            {
                sign = roadSpot.trafficSign;
                if (sign != TrafficSign.Empty)
                {
                    return true;
                }
            }
            sign = TrafficSign.Empty;
            return false;
        }

        public bool TryGetTrafficLight(int position, out TrafficLight TL)
        {
            Situation roadSpot;
            if (dataCarsLocation.TryGetValue(position, out roadSpot))
            {
                TL = roadSpot.trafficLight;
                if (TL != TrafficLight.Empty)
                {
                    return true;
                }
            }
            TL = TrafficLight.Empty;
            return false;
        }

        public bool TryGetPlayer(out ActorCar playerCar)
        {
            foreach (var item in dataCarsLocation)
            {
                if (item.Value.player)
                {
                    playerCar = item.Value.actorCar;
                    return true;
                }
            }
            playerCar = null;
            return false;
        }

        #endregion

        private void SetComperativePositions()
        {
            int lengthOfCars = Toolbox.Get<DataArtSession>().MaxCars;
            ActorCar settingCar;
            ActorCar comperativeCar;
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
    }
}

