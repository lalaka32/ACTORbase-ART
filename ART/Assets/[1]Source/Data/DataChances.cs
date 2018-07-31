using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    [CreateAssetMenu(fileName = "DataChances", menuName = "Data/DataChances")]
    class DataChances : DataGame
    {
        [FoldoutGroup("Type of cross")] public int chanceOfQvalent;
        [FoldoutGroup("Type of cross")] public int chanceOfUnQvalent;
        [FoldoutGroup("Type of cross")] public int chanceOfRegularity;
        [FoldoutGroup("Type of cross")] [TagFilter(typeof(TypeOfCross))] public int defaultType;

        [FoldoutGroup("Count of cars")] public int MinToRandom;
        [FoldoutGroup("Count of cars")] public int MaxToRandom;

        //public int chanceOfVIP;

        public override void Dispose()
        {
            
        }
    }
}
