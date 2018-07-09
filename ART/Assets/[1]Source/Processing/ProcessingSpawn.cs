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
                        car.GetComponent<ActorCar>().HandleDestroyGO();
                    }
                }
                foreach (var sign in signs)
                {
                    if (sign != null)
                    {
                        Toolbox.Destroy(sign.gameObject);
                    }
                }
                Toolbox.Get<DataGameSession>().SetRoadData();
                Cross.actors[iCross].Get<DataCarsLocation>().positions.Clear();
                cars.Clear(); signs.Clear(); tls.Clear();
                if (Cross.actors[iCross].Get<DataSpotOfCars>() != null)
                {
                    SpawnCars(Cross.actors[iCross]);
                }
                if (Cross.actors[iCross].Get<DataSpotTrafficSign>() != null)
                {
                    SpawnSigns(Cross.actors[iCross]);
                }
            }
        }
        List<Transform> cars = new List<Transform>();
        List<Transform> tls = new List<Transform>();
        List<Transform> signs = new List<Transform>();
        void Spawn()
        {
            //Ставить столько перекрёствов сколько захочет плеер
            //Место каунт чило кросов чтобы спавнит
            for (int iCross = 0; iCross < CrossSpawnerSpots.actors.Count; iCross++)
            {
                //В спавн передавать тип переца
                Transform crossTransform = Toolbox.Get<FactoryCross>().Spawn(CrossSpawnerSpots.actors[iCross].transform.position, Quaternion.identity, WorldParenters.None);
                crossTransform.eulerAngles = new Vector3(-90, 0, 0);

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
                    SpawnSigns(Cross.actors[iCross]);
                }
                if (Cross.actors[iCross].Get<DataSpotOfCars>() != null)
                {
                    SpawnCars(Cross.actors[iCross]);
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
        
        void SpawnSigns(Actor cross)
        {
            if (Toolbox.Get<DataGameSession>().dataRoadSituation.Sign)
            {
                Transform signMain1 = Toolbox.Get<FactorySign>().SpawnSignMain(cross.Get<DataSpotTrafficSign>().Positions[0].selfTransform.position, cross.Get<DataSpotTrafficSign>().Positions[0].selfTransform.rotation, cross.transform.Find("Signs"));
                Transform signMain2 = Toolbox.Get<FactorySign>().SpawnSignMain(cross.Get<DataSpotTrafficSign>().Positions[2].selfTransform.position, cross.Get<DataSpotTrafficSign>().Positions[2].selfTransform.rotation, cross.transform.Find("Signs"));
                Transform signSecondary1 = Toolbox.Get<FactorySign>().SpawnSignSecondary(cross.Get<DataSpotTrafficSign>().Positions[1].selfTransform.position, cross.Get<DataSpotTrafficSign>().Positions[1].selfTransform.rotation, cross.transform.Find("Signs"));
                Transform signSecondary2 = Toolbox.Get<FactorySign>().SpawnSignSecondary(cross.Get<DataSpotTrafficSign>().Positions[3].selfTransform.position, cross.Get<DataSpotTrafficSign>().Positions[3].selfTransform.rotation, cross.transform.Find("Signs"));

                //добавление трансформов знаков в лист
                for (int iSign = 0; iSign < cross.transform.Find("Signs").childCount; iSign++)
                {
                    signs.Add(cross.transform.Find("Signs").GetChild(iSign));
                }
            }
        }

    }
}
