﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class ProcessingSpawn : ProcessingBase, IMustBeWiped, IReceive<SignalRespawn>
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
                ProcessingSignals.Default.Send<SignalKillCars>();
                foreach (var sign in signs)
                {
                    if (sign != null)
                    {
                        Toolbox.Destroy(sign.gameObject);
                    }
                }
                Toolbox.Get<DataGameSession>().SetRoadData();
                Cross.actors[iCross].Get<DataCarsLocation>().positions.Clear();
                signs.Clear(); tls.Clear();
                if (Cross.actors[iCross].Get<DataSpotOfCars>() != null)
                {
                    SpawnCars(Cross.actors[iCross]);
                    Homebrew.Timer.Add(0.2f, ()=>ProcessingSignals.Default.Send(new SignalCarSpawn()));
                }
                if (Cross.actors[iCross].Get<DataSpotTrafficSign>() != null)
                {
                    SpawnSigns(Cross.actors[iCross]);
                }
            }
        }
        List<Transform> tls = new List<Transform>();
        List<Transform> signs = new List<Transform>();
        void Spawn()
        {
            //Ставить столько перекрёствов сколько захочет плеер
            //Место каунт чило кросов чтобы спавнит
            for (int iCross = 0; iCross < CrossSpawnerSpots.actors.Count; iCross++)
            {
                //В спавн передавать тип переца
                SpawnCross(CrossSpawnerSpots.actors[iCross]);

                //Место этого уловия что угодно и у нас динамически настроваемый перец
                if (Cross.actors[iCross].Get<DataSpotTrafficLight>() != null)
                {
                    SpawnTL(Cross.actors[iCross]);
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
                    ProcessingSignals.Default.Send(new SignalCarSpawn());
                }
            }
        }

        void SpawnCross(Actor cross)
        {
            Transform crossTransform = Toolbox.Get<FactoryCross>().Spawn(cross.transform.position, Quaternion.identity, WorldParenters.None);
            crossTransform.eulerAngles = new Vector3(-90, 0, 0);
        }

        void SpawnTL(Actor cross)
        {
            for (int iTrafficLight = 0; iTrafficLight < cross.Get<DataSpotTrafficLight>().Positions.Count; iTrafficLight++)
            {
                Toolbox.Get<FactoryTrafficLight>().SpawnTL(cross.Get<DataSpotTrafficLight>().Positions[iTrafficLight].selfTransform.position, cross.Get<DataSpotTrafficLight>().Positions[iTrafficLight].selfTransform.rotation, cross.transform.Find("Lights"));
            }
        }

        void SpawnCars(Actor cross)
        {
            //Тут рандомить позишн
            //cross.Get<DataSpotOfCars>().Positions.Shaffle();
            for (int iCar = 0; iCar < Toolbox.Get<DataGameSession>().dataRoadSituation.CountOfCars; iCar++)
            {
                var car = Toolbox.Get<FactoryCar>().SpawnCar(cross.Get<DataSpotOfCars>().Positions[iCar].selfTransform.position, cross.Get<DataSpotOfCars>().Positions[iCar].selfTransform.rotation, cross.selfTransform, cross.Get<DataSpotOfCars>().Positions[iCar].directions);
                cross.Get<DataCarsLocation>().positions.Add((int)cross.Get<DataSpotOfCars>().Positions[iCar].position, car.GetComponent<ActorCar>());
            }
            //FastDeb.DebugDictionaryOut(cross.Get<DataCarsLocation>().positions);
            Actor player= cross.Get<DataCarsLocation>().positions.Random();
            player.tags.Add(Tag.PlayerCar);
            player.selfTransform.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
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
