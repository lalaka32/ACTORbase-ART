using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    [CreateAssetMenu(fileName = "FactoryRules", menuName = "Factories/FactoryRules")]
    class FactoryRules: Factory
    {
        [TagFilter(typeof(Rule))] public int tagRule;
        public List<Condition> conditions = new List<Condition>();
    }
    [Serializable]
    public class Condition
    {
        public bool car;
        [TagFilter(typeof(ComperativePos))] public int comperativePosition;
        [TagFilter(typeof(Direction))] public int direction;
        public bool isVIP;
        public TrafficSign hisTrafficSign;
        public TrafficLight hisTrafficLight;
    }
}
