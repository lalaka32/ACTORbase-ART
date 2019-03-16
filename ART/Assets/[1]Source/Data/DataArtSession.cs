using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BeeFly
{
    [CreateAssetMenu(fileName = "DataARTSession", menuName = "Data/DataARTSession")]
    public class DataArtSession : DataGame
    {
        public int NumberOfQuestion { get; set; }
        public List<Situation> CrossSituation;
        public int MaxCars = 4;
        [TagFilter(typeof(TypeOfCross))] public int typeOfCross;
        public int countOfCars;

        public void SetRoadData(int typeOfCross, int countOfCars)
        {
            this.typeOfCross = typeOfCross;
            this.countOfCars = countOfCars;
        }
        public Situation GetSituation(Actor car)
        {
            if (car.tags.Contain(Tag.Car))
            {
                foreach (var situation in CrossSituation)
                {
                    if (situation.actorCar == car)
                    {
                        return situation;
                    }
                }
            }
            return null;
        }
        public Situation GetSituation(int position)
        {
            foreach (var situation in CrossSituation)
            {
                if (situation.position == position)
                {
                    return situation;
                }
            }

            return null;
        }
        public List<Actor> GetCars(int priority)
        {
            List<Actor> cars = new List<Actor>();
            foreach (var situation in CrossSituation)
            {
                if (!situation.car)
                    continue;
                if (situation.actorCar.Get<DataPriority>().priority == priority)
                {
                    cars.Add(situation.actorCar);
                }
            }
            return cars;
        }
        public bool IsGreen(int priority)
        {
            foreach (var situation in CrossSituation)
            {
                if (!situation.car)
                    continue;
                if (situation.priority == priority)
                {
                    if (situation.trafficLight == TrafficLight.Green)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public int GetMaxPriority()
        {
            int max = 0;
            foreach (var situation in CrossSituation)
            {
                if (!situation.car)
                    continue;
                if (situation.actorCar.Get<DataPriority>().priority > max)
                {
                    max = situation.actorCar.Get<DataPriority>().priority;
                }
            }
            
            return max;
        }
        public override void Dispose()
        {
            CrossSituation = null;
        }
    }

}
