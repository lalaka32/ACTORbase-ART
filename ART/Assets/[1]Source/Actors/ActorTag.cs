using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    public class ActorTag: Homebrew.Actor
    {
        [FoldoutGroup("Setup")] public List<DataTag> IDs;

        protected override void Setup()
        {
            for (int i = 0; i < IDs.Count; i++)
            {
                tags.Add(IDs[i].id);
            }
        }
    }
}
