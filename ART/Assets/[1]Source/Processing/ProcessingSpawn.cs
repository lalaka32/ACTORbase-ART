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
        //Мда чёт пока не идёт у меня мыслей
        //Я думаю как разделать наши группы чтобы
        //Мы могли делать 2 перекрёстка с разной конфигурацией

        //Я так запарился потому что хочу чтобы можно было в настр выбрать 
        //число перекрёстков))
        [GroupBy(Tag.SpawnerOfCross)]
        Group CrossSpawnerSpot;

        [GroupBy(Tag.CarPosition)]
        Group CarsSpawnerSpots;
        [GroupBy(Tag.TLPosition)]
        Group TLSpawnerSpots;
        [GroupBy(Tag.SignPosition)]
        Group SignSpawnerSpots;

        [GroupBy(Tag.OneLane)]
        Group Cross;

        public ProcessingSpawn()
        {
            Homebrew.Timer.Add(0.1f, () => Spawn());
        }
        void Spawn()
        {
            //Ставить столько перекрёствов сколько захочет плеер
            for (int indexCross = 0; indexCross < CrossSpawnerSpot.actors.Count; indexCross++)
            {
                Toolbox.Get<FactoryCross>().Spawn(CrossSpawnerSpot.actors[indexCross].transform.position, Quaternion.identity, WorldParenters.None);
                Toolbox.Get<FactoryCross>().Cross.eulerAngles = new Vector3(-90, 0, 0);
                for (int indexTL = 0; indexTL < TLSpawnerSpots.actors.Count; indexTL++)
                {
                    Toolbox.Get<FactoryTrafficLight>().SpawnTL(TLSpawnerSpots.actors[indexTL].transform.position, Quaternion.identity, Cross.actors[indexCross].transform);
                }
                //наверн сразу заспавнить всё а потом уже разбираться 
                //где что стоит или не стоит 
                for (int indexSign = 0; indexSign < SignSpawnerSpots.actors.Count; indexSign++)
                {
                    Toolbox.Get<FactorySign>().SpawnSignMain(SignSpawnerSpots.actors[indexSign].transform.position, Quaternion.identity, Cross.actors[indexCross].transform);
                    Toolbox.Get<FactorySign>().SpawnSignSecondary(SignSpawnerSpots.actors[indexSign].transform.position, Quaternion.identity, Cross.actors[indexCross].transform);
                }
            }  
        }
    }
}
