/*===============================================================
Product:    Shoot off their lumps
Developer:  Dimitry Pixeye - pixeye@hbrew.store
Company:    Homebrew - http://hbrew.store
Date:       10/12/2017 14:09
================================================================*/


using UnityEngine;

namespace Homebrew
{
	[CreateAssetMenu(fileName = "DataGameSession", menuName = "Data/DataGameSession")]
	public class DataGameSession : DataGame
	{
        public string Token { get; set; }
		public void CleanSession()
		{
            Token = null;
		}


		public override void Dispose()
		{
			CleanSession();
		}
	}
}