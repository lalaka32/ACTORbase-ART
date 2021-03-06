﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    public class ActorTag: Actor
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
