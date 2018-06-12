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
        [GroupBy(Tag.CarPosition)]
        Group CarsSpawnerSpots;
        [GroupBy(Tag.TLPosition)]
        Group TLSpawnerSpots;
        [GroupBy(Tag.SignPosition)]
        Group SignSpawnerSpots;

        public ProcessingSpawn()
        {
            Homebrew.Timer.Add(0.1f, () => Spawn());
        }
        void Spawn()
        {
            Toolbox.Get<FactoryCross>().Spawn(CrossSpawnerSpot.actors[0].transform.position, Quaternion.identity,WorldParenters.None);
            Toolbox.Get<FactoryCross>().Cross.eulerAngles = new Vector3(-90, 0, 0);
            for (int i = 0; i < TLSpawnerSpots.actors.Count; i++)
            {
                Toolbox.Get<FactoryCross>().SpawnTL(TLSpawnerSpots.actors[i].transform.position,Quaternion.identity);
            }
            //наверн сразу заспавнить всё а потом уже разбираться 
            //где что стоит или не стоит 
            for (int i = 0; i < SignSpawnerSpots.actors.Count; i++)
            {
                Toolbox.Get<FactoryCross>().SpawnSignMain(SignSpawnerSpots.actors[i].transform.position, Quaternion.identity);
                Toolbox.Get<FactoryCross>().SpawnSignSecondary(SignSpawnerSpots.actors[i].transform.position, Quaternion.identity);
            }
        }
    }
}
