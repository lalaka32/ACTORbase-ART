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
        public DataRoadSituation dataRoadSituation;
        public void SetRoadData()
        {
            dataRoadSituation = new DataRoadSituation();
            dataRoadSituation.CountOfCars = Random.Range(2, 4);
            dataRoadSituation.VIP = Convert.ToBoolean(Random.Range(0,2));
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
    }
}