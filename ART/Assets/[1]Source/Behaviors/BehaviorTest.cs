/*===============================================================
Product:    Unity3dTools
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       5/21/2018 9:08 PM
================================================================*/


using BeeFly;
using UnityEngine;

namespace Homebrew
{
    public class BehaviorTest : Behavior, ITick
    {
        [Bind] private DataTest test;
        [Bind] DataCarsLocation dataCarsLocation;

        public override void OnTick()
        {
            //Debug.Log(test.Test.ToString());
            //Debug.Log("HideFlags");
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    foreach (var item in dataCarsLocation.positions)
            //    {
            //        Debug.Log(item.Key + "---------" + item.Value.Get<DataDirection>().direction);
            //    }
            //}
        }
    }
}