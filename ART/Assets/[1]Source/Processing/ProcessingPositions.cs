using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class ProcessingPositions : ProcessingBase, IReceive<SignalSetComperativePositions>, IReceive<SignalSetSituations>, IMustBeWipedOut
    {
        public static ProcessingPositions Default;

        public Dictionary<int, Situation> dataCarsLocation = new Dictionary<int, Situation>();

        public void HandleSignal(SignalSetComperativePositions arg)
        {
            SetComperativePositions(Toolbox.Get<DataArtSession>().MaxCars);
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

        #endregion

        private void SetComperativePositions(int lengthOfCars)
        {
            ActorCar settingCar;
            Situation comperativeSituation;
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
                        if (dataCarsLocation.TryGetValue(comperativeIndex, out comperativeSituation))
                        {
                            settingCar.Get<DataComperativeCars>().comperative.Add(comperativePosition, comperativeSituation);
                            //Debug.Log("comperativePosition" + comperativePosition + "---------------- comperativeActor" + comperativeSituation.position);
                        }
                    }
                }
            }
        }
    }
}

