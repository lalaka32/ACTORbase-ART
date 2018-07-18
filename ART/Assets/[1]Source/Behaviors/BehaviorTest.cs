/*===============================================================
Product:    Unity3dTools
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       5/21/2018 9:08 PM
================================================================*/


using BeeFly;
using UnityEngine;
using FastDeb;

namespace Homebrew
{
    public class BehaviorTest : Behavior, ITick
    {
        [Bind] DataTest data;
        public override void OnTick()
        {
            data.Test.Print();
        }
    }
}