using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;
using FastDeb;

namespace BeeFly
{
    public class BehaviorMove : Behavior, ITick
    {
        [Bind] DataCarsLocation dataCarsLocation;

        public override void OnTick()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                dataCarsLocation.positions.PrintDictionary();
            }
        }
    }
}
