using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class ProcessingSpawn : ProcessingBase, IMustBeWiped
    {
        [GroupBy(Tag.Cross)]
        Group CrossSpawnerSpot;


        public ProcessingSpawn()
        {
            Homebrew.Timer.Add(0.1f, () => Spawn());

        }
        void Spawn()
        {
            Toolbox.Get<FactoryCross>().Spawn(CrossSpawnerSpot.actors[0].transform.position, Quaternion.identity);
        }
    }
}
