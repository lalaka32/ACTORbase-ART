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
    public partial class DataGameSession : DataGame
    {

        public void CleanSession()
        {
            
        }

        public override void Dispose()
        {
            CleanSession();
        }
    }
}