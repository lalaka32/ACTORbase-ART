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

        public void SetRoadData(int typeOfCross,int countOfCars)
        {
            this.typeOfCross = typeOfCross;
            this.countOfCars = countOfCars;
        }
        public override void Dispose()
        {
            CrossSituation = null;
        }
    }
    
}
