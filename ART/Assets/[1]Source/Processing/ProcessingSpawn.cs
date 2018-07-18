using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class ProcessingSpawn : ProcessingBase, IMustBeWipedOut, IReceive<SignalRespawn>
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
            SpawnCross(CrossSpawnerSpots.actors[0]);
            SpawnTL(Cross.actors[0]);
            SpawnSigns(Cross.actors[0]);
            SpawnCars(Cross.actors[0]);
            ProcessingSignals.Default.Send(new SignalSpawnEnded());
        }
        public void HandleSignal(SignalRespawn arg)
        {
            SpawnCars(Cross.actors[0]);
            ProcessingSignals.Default.Send(new SignalSpawnEnded());
        }

        void SpawnCross(Actor cross)
        {
            Toolbox.Get<FactoryRoad>().Spawn(cross.transform.position, Quaternion.identity, Tag.Cross);
        }

        void SpawnTL(Actor cross)
        {
            for (int iTrafficLight = 0; iTrafficLight < cross.Get<DataSpotTrafficLight>().Positions.Count; iTrafficLight++)
            {
                Toolbox.Get<FactoryRoad>().Spawn(cross.Get<DataSpotTrafficLight>().Positions[iTrafficLight].selfTransform.position, cross.Get<DataSpotTrafficLight>().Positions[iTrafficLight].selfTransform.rotation, Tag.TrafficLight, cross.transform.Find("Lights"));
            }
        }

        void SpawnSigns(Actor cross)
        {
            //Не нра
            if (Toolbox.Get<DataGameSession>().dataRoadSituation.Sign)
            {
                Toolbox.Get<FactoryRoad>().Spawn(cross.Get<DataSpotTrafficSign>().Positions[0].selfTransform.position, cross.Get<DataSpotTrafficSign>().Positions[0].selfTransform.rotation, Tag.SignMain, cross.transform.Find("Signs"));
                Toolbox.Get<FactoryRoad>().Spawn(cross.Get<DataSpotTrafficSign>().Positions[2].selfTransform.position, cross.Get<DataSpotTrafficSign>().Positions[2].selfTransform.rotation, Tag.SignMain, cross.transform.Find("Signs"));
                Toolbox.Get<FactoryRoad>().Spawn(cross.Get<DataSpotTrafficSign>().Positions[1].selfTransform.position, cross.Get<DataSpotTrafficSign>().Positions[1].selfTransform.rotation, Tag.SignSecondary, cross.transform.Find("Signs"));
                Toolbox.Get<FactoryRoad>().Spawn(cross.Get<DataSpotTrafficSign>().Positions[3].selfTransform.position, cross.Get<DataSpotTrafficSign>().Positions[3].selfTransform.rotation, Tag.SignSecondary, cross.transform.Find("Signs"));
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
            SetPlayer(cross);
        }

        void SetPlayer(Actor cross)
        {
            Actor player = cross.Get<DataCarsLocation>().positions.Random();
            player.tags.Add(Tag.PlayerCar);
            player.selfTransform.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
        }
    }
}
