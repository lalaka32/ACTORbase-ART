using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    [CreateAssetMenu(fileName = "FactorySituations", menuName = "Factories/FactorySituations")]
    class FactorySituation : Factory
    {
        [TagFilter(typeof(Situations))] public int tagSituation;
        public List<Situation> Cases;
    }
    [Serializable]
    class Situation
    {
        public TrafficLight trafficLight;
        public TrafficSign trafficSign;
        [TagFilter(typeof(Position))] public int position;
    }
}
