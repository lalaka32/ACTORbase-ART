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

        protected override void Setup()
        {
            for (int i = 0; i < IDs.Count; i++)
            {
                tags.Add(IDs[i].id);
            }
            Add(directions);
        }
    }
}
