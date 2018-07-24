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
        public TrafficLight trafficLight = TrafficLight.Empty;
        public TrafficSign trafficSign = TrafficSign.Empty;
        [TagFilter(typeof(Position))] public int position = Position.First;
        public bool car = false;
        public DataDirection direction = new DataDirection(Direction.None);
        // public bool VIP;
        public bool player = false;
    }
}
