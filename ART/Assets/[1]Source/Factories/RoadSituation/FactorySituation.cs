using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    [Serializable]
    [CreateAssetMenu(fileName = "FactorySituations", menuName = "Factories/FactorySituations")]
    public class FactorySituation : Factory
    {
        [TagFilter(typeof(Situations))] public int tagSituation;
        public List<Situation> Cases = new List<Situation>();
    }
    [Serializable]
    public class Situation
    {
        [TagFilter(typeof(TrafficLight))] public int trafficLight = TrafficLight.Empty;
        [TagFilter(typeof(TrafficSign))] public int trafficSign = TrafficSign.Empty;
        [TagFilter(typeof(Position))] public int position = Position.First;

        public bool car = false;
        public DataDirection direction = new DataDirection(Direction.None);
        // public bool VIP;
        public bool player = false;
        [HideInInspector]
        public int priority;
        [HideInInspector]
        public ActorCar actorCar;

        internal void SetRoadData(ActorCar car, int trafficLight, int trafficSign)
        {

        }

        public Situation(ActorCar actorCar = null, int trafficLight = TrafficLight.Empty, int trafficSign = TrafficSign.Empty , int position = Position.First, DataDirection direction = null , bool car = false,  bool player = false)
        {
            this.trafficLight = trafficLight;
            this.trafficSign = trafficSign;
            this.position = position;
            this.car = car;
            this.direction = direction;
            this.player = player;
        }
    }
}
