using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class ProcessingSpawn : ProcessingBase, IMustBeWiped, IRecieve<SignalRespawn>
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

        public void HandleSignal(SignalRespawn arg)
        {
            for (int iCross = 0; iCross < CrossSpawnerSpots.actors.Count; iCross++)
            {
                Toolbox.Get<DataGameSession>().NumberOfVoprosa++;
                foreach (var car in cars)
                {
                    if (car != null)
                    {
                        Toolbox.Destroy(car.gameObject);
                    }
                }
                Toolbox.Get<DataGameSession>().SetRoadData();
                Cross.actors[iCross].Get<DataCarsLocation>().positions.Clear();
                //Тут не только кор чистить но и знаки и светофоры
                if (Cross.actors[iCross].Get<DataSpotOfCars>() != null)
                {
                    SpawnCars(Cross.actors[iCross]);
                    ProcessingSignals.Default.Send<SignalCarSpawn>();
                }

            }
        }
        List<Transform> cars = new List<Transform>();
        void Spawn()
        {
            //Ставить столько перекрёствов сколько захочет плеер
            //Место каунт чило кросов чтобы спавнит
            for (int iCross = 0; iCross < CrossSpawnerSpots.actors.Count; iCross++)
            {
                //В спавн передавать тип переца
                Transform crossTransform = Toolbox.Get<FactoryCross>().Spawn(CrossSpawnerSpots.actors[iCross].transform.position, Quaternion.identity, WorldParenters.None);
                Toolbox.Get<FactoryCross>().Cross.eulerAngles = new Vector3(-90, 0, 0);

                //Место этого уловия что угодно и у нас динамически настроваемый перец
                if (Cross.actors[iCross].Get<DataSpotTrafficLight>() != null)
                {
                    for (int iTrafficLight = 0; iTrafficLight < Cross.actors[iCross].Get<DataSpotTrafficLight>().Positions.Count; iTrafficLight++)
                    {
                        Toolbox.Get<FactoryTrafficLight>().SpawnTL(Cross.actors[iCross].Get<DataSpotTrafficLight>().Positions[iTrafficLight].selfTransform.position, Cross.actors[iCross].Get<DataSpotTrafficLight>().Positions[iTrafficLight].selfTransform.rotation, crossTransform.Find("Lights"));
                    }
                }
                //наверн сразу заспавнить всё а потом уже разбираться 
                //где что стоит или не стоит 
                if (Cross.actors[iCross].Get<DataSpotTrafficSign>() != null)
                {
                    for (int iTrafficSign = 0; iTrafficSign < Cross.actors[iCross].Get<DataSpotTrafficSign>().Positions.Count; iTrafficSign++)
                    {
                        Toolbox.Get<FactorySign>().SpawnSignMain(Cross.actors[iCross].Get<DataSpotTrafficSign>().Positions[iTrafficSign].selfTransform.position, Cross.actors[iCross].Get<DataSpotTrafficSign>().Positions[iTrafficSign].selfTransform.rotation, crossTransform.Find("Signs"));
                        Toolbox.Get<FactorySign>().SpawnSignSecondary(Cross.actors[iCross].Get<DataSpotTrafficSign>().Positions[iTrafficSign].selfTransform.position, Cross.actors[iCross].Get<DataSpotTrafficSign>().Positions[iTrafficSign].selfTransform.rotation, crossTransform.Find("Signs"));
                    }
                }
                if (Cross.actors[iCross].Get<DataSpotOfCars>() != null)
                {
                    SpawnCars(Cross.actors[iCross]);
                    ProcessingSignals.Default.Send<SignalCarSpawn>();
                }

            }
        }
        void SpawnCars(Actor cross)
        {
            //Тут рандомить позишн
            cross.Get<DataSpotOfCars>().Positions.Shaffle();
            for (int iCar = 0; iCar < Toolbox.Get<DataGameSession>().dataRoadSituation.CountOfCars; iCar++)
            {
                var car = Toolbox.Get<FactoryCar>().SpawnCar(cross.Get<DataSpotOfCars>().Positions[iCar].selfTransform.position, cross.Get<DataSpotOfCars>().Positions[iCar].selfTransform.rotation, cross.selfTransform, cross.Get<DataSpotOfCars>().Positions[iCar].directions);
                cars.Add(car);
                cross.Get<DataCarsLocation>().positions.Add(iCar, car.GetComponent<ActorCar>());
            }
            cross.Get<DataCarsLocation>().positions.Random().tags.Add(Tag.PlayerCar);
        }

    }
}
