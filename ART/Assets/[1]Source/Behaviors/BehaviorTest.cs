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
        public override void OnTick()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
            }
        }
    }
}