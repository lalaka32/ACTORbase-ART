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
        Group CrossSpawnerSpots;

        [GroupBy(Tag.Cross)]
        Group Cross;

        public ProcessingSpawn()
        {
            Homebrew.Timer.Add(0.2f, () => Spawn());
        }
        void Spawn()
        {
            //Ставить столько перекрёствов сколько захочет плеер
            //Место каунт чило кросов чтобы спавнит
            for (int iCross = 0; iCross < CrossSpawnerSpots.actors.Count; iCross++)
            {
                
                //В спавн передавать тип переца
                Transform crossTransform= Toolbox.Get<FactoryCross>().Spawn(CrossSpawnerSpots.actors[iCross].transform.position, Quaternion.identity, WorldParenters.None);
                Toolbox.Get<FactoryCross>().Cross.eulerAngles = new Vector3(-90, 0, 0);

                //Место этого уловия что угодно и у нас динамически настроваемый перец
                if (Cross.actors[iCross].Get<DataSpotTrafficLight>() != null)
                {
                    for (int iTrafficLight = 0; iTrafficLight < Cross.actors[iCross].Get<DataSpotTrafficLight>().Positions.Count; iTrafficLight++)
                    {
                        Toolbox.Get<FactoryTrafficLight>().SpawnTL(Cross.actors[iCross].Get<DataSpotTrafficLight>().Positions[iTrafficLight].selfTransform.position, Cross.actors[iCross].Get<DataSpotTrafficLight>().Positions[iTrafficLight].selfTransform.rotation, crossTransform);
                    }
                }
                //наверн сразу заспавнить всё а потом уже разбираться 
                //где что стоит или не стоит 
                if (Cross.actors[iCross].Get<DataSpotTrafficSign>() != null)
                {                       
                    for (int iTrafficSign = 0; iTrafficSign < Cross.actors[iCross].Get<DataSpotTrafficSign>().Positions.Count; iTrafficSign++)
                    {
                        Toolbox.Get<FactorySign>().SpawnSignMain(Cross.actors[iCross].Get<DataSpotTrafficSign>().Positions[iTrafficSign].selfTransform.position, Cross.actors[iCross].Get<DataSpotTrafficSign>().Positions[iTrafficSign].selfTransform.rotation, crossTransform);
                        Toolbox.Get<FactorySign>().SpawnSignSecondary(Cross.actors[iCross].Get<DataSpotTrafficSign>().Positions[iTrafficSign].selfTransform.position, Cross.actors[iCross].Get<DataSpotTrafficSign>().Positions[iTrafficSign].selfTransform.rotation, crossTransform);
                    }
                }
                if (Cross.actors[iCross].Get<DataSpotOfCars>() != null)
                {
                    //Тут рандомить позишн
                    for (int iCar = 0; iCar < Cross.actors[iCross].Get<DataSpotOfCars>().Positions.Count; iCar++)
                    {
                        var car = Toolbox.Get<FactoryCar>().SpawnCar(Cross.actors[iCross].Get<DataSpotOfCars>().Positions[iCar].selfTransform.position, Cross.actors[iCross].Get<DataSpotOfCars>().Positions[iCar].selfTransform.rotation, crossTransform, Cross.actors[iCross].Get<DataSpotOfCars>().Positions[iCar].directions);
                        Cross.actors[iCross].Get<DataCarsLocation>().positions.Add(iCar, car.GetComponent<ActorCar>()); 
                    }
                }
            }
        }
    }
}
