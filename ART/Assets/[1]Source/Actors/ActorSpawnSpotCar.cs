using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Homebrew;

namespace BeeFly
{
    //Убрать
    public class ActorSpawnSpotCar : Actor
    {
        [FoldoutGroup("Setup")] public List<DataTag> IDs;


        protected override void SetupBehaviors()
        {
            
        }

        protected override void SetupData()
        {

            for (int i = 0; i < IDs.Count; i++)
            {
                tags.Add(IDs[i].id);
            }
        }
    }
}
