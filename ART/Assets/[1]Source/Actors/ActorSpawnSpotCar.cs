using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Homebrew;

namespace BeeFly
{
    public class ActorSpawnSpotCar : Actor
    {
        [FoldoutGroup("Setup")] public List<DataTag> IDs;
        [FoldoutGroup("Setup")] public Direction[] directions;

        protected override void SetupBehaviors()
        {
            
        }

        protected override void SetupData()
        {

            Add(directions);
            for (int i = 0; i < IDs.Count; i++)
            {
                tags.Add(IDs[i].id);
            }
        }
    }
}
