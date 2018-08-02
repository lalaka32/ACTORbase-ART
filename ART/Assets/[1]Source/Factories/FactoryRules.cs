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
        public SelfCondition selfCondition;
    }
    [Serializable]
    public class Condition
    {
        public bool car;
        [TagFilter(typeof(ComperativePos))] public int comperativePosition;
        [TagFilter(typeof(Direction))] public int hisDirection;
        public bool isVIP;
        [TagFilter(typeof(TrafficSign))] public int hisTrafficSign;
        [TagFilter(typeof(TrafficLight))] public int hisTrafficLight;
    }
    [Serializable]
    public class SelfCondition
    {
        [TagFilter(typeof(Direction))] public int selfDirection;
        public bool isVIP;
        [TagFilter(typeof(TrafficSign))] public int selfTrafficSign;
        [TagFilter(typeof(TrafficLight))] public int selfTrafficLight;
    }
}
