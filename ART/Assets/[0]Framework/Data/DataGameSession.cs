/*===============================================================
Product:    Shoot off their lumps
Developer:  Dimitry Pixeye - pixeye@hbrew.store
Company:    Homebrew - http://hbrew.store
Date:       10/12/2017 14:09
================================================================*/


using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Homebrew
{
	[CreateAssetMenu(fileName = "DataGameSession", menuName = "Data/DataGameSession")]
	public class DataGameSession : DataGame
	{
        public DataRoadSituation dataRoadSituation = new DataRoadSituation();
        public int NumberOfVoprosa { get; set; }
        public void SetRoadData()
        {
            dataRoadSituation.CountOfCars = Random.Range(2, 4);
            dataRoadSituation.VIP = Convert.ToBoolean(Random.Range(0,2));
            dataRoadSituation.Sign = Convert.ToBoolean(Random.Range(0, 2));
            dataRoadSituation.IndexOfVIP = Random.Range(1, dataRoadSituation.CountOfCars);
            dataRoadSituation.TrafficLight = (TrafficL)Random.Range(0, 3);
        }
		public void CleanSession()
		{

		}


		public override void Dispose()
		{
			CleanSession();
		}
	}
    public class DataRoadSituation
    {
        public int CountOfCars { get;  set; }
        public bool VIP { get;  set; }
        public int IndexOfVIP { get; set; }
        public bool Sign { get; set; }
        public TrafficL TrafficLight { get; set; }
    }
}

    public enum TrafficL : byte { off, on, empty }