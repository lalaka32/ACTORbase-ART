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
    [CreateAssetMenu(fileName = "DataGameSession", menuName = "Data/DataGameSession")]
    public class DataArtSession : DataGame
    {
        public DataRoadSituation dataRoadSituation;
        public int NumberOfQuestion { get; set; }
        public void SetRoadData()
        {
            dataRoadSituation = new DataRoadSituation();
            dataRoadSituation.CountOfCars = Random.Range(2, 4);
            dataRoadSituation.VIP = Convert.ToBoolean(Random.Range(0, 2));
            dataRoadSituation.Sign = Convert.ToBoolean(Random.Range(0, 2));
            dataRoadSituation.IndexOfVIP = Random.Range(1, dataRoadSituation.CountOfCars);
            dataRoadSituation.TrafficLight = Convert.ToBoolean(Random.Range(0, 2));
        }
        public override void Dispose()
        {
            dataRoadSituation = null;
        }
    }
    public class DataRoadSituation
    {
        public int CountOfCars { get; set; }
        public bool VIP { get; set; }
        public int IndexOfVIP { get; set; }
        public bool Sign { get; set; }
        public bool TrafficLight { get; set; }
        public const int MaxCars = 4;
    }
    public enum TrafficL : byte { off, on, empty }
}
