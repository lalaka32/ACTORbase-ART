using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    public class BehaviorMove : Behavior, ITick
    {
        [Bind] DataCarsLocation dataCarsLocation;

        public override void OnTick()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                foreach (var item in dataCarsLocation.positions)
                {
                    Debug.Log(item.Key + "---------" + item.Value.Get<DataDirection>().direction);
                }
            }
        }
    }
}
