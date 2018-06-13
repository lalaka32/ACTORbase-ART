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

        [GroupBy(Tag.OneLane)]
        Group Cross;

        public ProcessingSpawn()
        {
            Homebrew.Timer.Add(0.1f, () => Spawn());
        }
        void Spawn()
        {
            //Ставить столько перекрёствов сколько захочет плеер
            //Место каунт чило кросов чтобы спавнит
            for (int indexCross = 0; indexCross < CrossSpawnerSpot.actors.Count; indexCross++)
            {
                //В спавн передавать тип переца
                Toolbox.Get<FactoryCross>().Spawn(CrossSpawnerSpot.actors[indexCross].transform.position, Quaternion.identity, WorldParenters.None);
                Toolbox.Get<FactoryCross>().Cross.eulerAngles = new Vector3(-90, 0, 0);

                //Место этого уловия что угодно и у нас динамически настроваемый перец
                if (Cross.actors[indexCross].Get<DataSpotTrafficLight>()!=null)
                {
                    for (int indexTL = 0; indexTL < Cross.actors[indexCross].Get<DataSpotTrafficLight>().Positions.Count; indexTL++)
                    {
                        Toolbox.Get<FactoryTrafficLight>().SpawnTL(Cross.actors[indexCross].Get<DataSpotTrafficLight>().Positions[indexTL].selfTransform.position, Quaternion.identity, Cross.actors[indexCross].selfTransform);
                    }
                }
                //наверн сразу заспавнить всё а потом уже разбираться 
                //где что стоит или не стоит 
                if (Cross.actors[indexCross].Get<DataSpotTrafficSign>() != null)
                {
                    for (int indexSign = 0; indexSign < Cross.actors[indexCross].Get<DataSpotTrafficSign>().Positions.Count; indexSign++)
                    {
                        Toolbox.Get<FactorySign>().SpawnSignMain(Cross.actors[indexCross].Get<DataSpotTrafficSign>().Positions[indexSign].selfTransform.position, Quaternion.identity, Cross.actors[indexCross].selfTransform);
                        Toolbox.Get<FactorySign>().SpawnSignSecondary(Cross.actors[indexCross].Get<DataSpotTrafficSign>().Positions[indexSign].selfTransform.position, Quaternion.identity, Cross.actors[indexCross].selfTransform);
                    }
                }
            }  
        }
    }
}
