using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Homebrew;

namespace BeeFly
{
    public class ActorCarSpot : Actor
    {
        [FoldoutGroup("Setup")] public List<DataTag> IDs;
        [FoldoutGroup("Setup")] public Direction[] directions;
        [FoldoutGroup("Setup")] public Position position;

        protected override void SetupBehaviors()
        {
            
        }

        protected override void SetupData()
        {

            Add(directions);
            Add(position);
            for (int i = 0; i < IDs.Count; i++)
            {
                tags.Add(IDs[i].id);
            }
        }
    }
    public enum Position
    {
        First, Second, Third, Fourth
    }
}
