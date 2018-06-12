using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    class ActorTag:Actor
    {
        [FoldoutGroup("Setup")] public List<DataTag> spotsRespawn;

        protected override void Setup()
        {
            for (int i = 0; i < spotsRespawn.Count; i++)
            {
                tags.Add(spotsRespawn[i].id);
            }
        }
    }
}
