using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class ProcessingSpawn : ProcessingBase, IMustBeWipedOut, IReceive<SignalSpawnCars>, IReceive<SignalInitialSpawn>
    {
        //Мда чёт пока не идёт у меня мыслей
        //Я думаю как разделать наши группы чтобы
        //Мы могли делать 2 перекрёстка с разной конфигурацией

        //Я так запарился потому что хочу чтобы можно было в настр выбрать 
        //число перекрёстков))

        [GroupBy(Tag.Cross)]
        Group Cross;

        [GroupBy(Tag.RoadSpot)]
        Group RoadSpots;

        public void HandleSignal(SignalInitialSpawn arg)
        {
            Spawn();
        }

        void Spawn()
        {
            for (int i = 0; i < RoadSpots.length; i++)
            {
                SpawnTL(RoadSpots.actors[i]);
                SpawnSign(RoadSpots.actors[i]);
            }
            SpawnCars();

        }
        public void HandleSignal(SignalSpawnCars arg)
        {
            SpawnCars();
        }

        void SpawnTL(Actor roadSpot)
        {
            var trafficLight = roadSpot.Get<DataTrafficLightSpot>().trafficLightSpot.selfTransform;
            Toolbox.Get<FactoryRoad>().Spawn(trafficLight.position, trafficLight.rotation, Tag.TrafficLight, Cross.actors[0].transform.Find("Lights"));
        }

        void SpawnSign(Actor roadSpot)
        {
            var signSpot = roadSpot.Get<DataSignSpot>().signSpot.selfTransform;
            Toolbox.Get<FactoryRoad>().Spawn(signSpot.position, signSpot.rotation, Tag.SignMain, Cross.actors[0].transform.Find("Signs"));
            Toolbox.Get<FactoryRoad>().Spawn(signSpot.position, signSpot.rotation, Tag.SignSecondary, Cross.actors[0].transform.Find("Signs"));
        }

        void SpawnCars()
        {
            for (int i = 0; i < Toolbox.Get<DataArtSession>().dataRoadSituation.CountOfCars; i++)
            {
                var carSpot = RoadSpots.actors[i].Get<DataCarSpot>().carSpot;
                var car = Toolbox.Get<FactoryCar>().SpawnCar(carSpot.selfTransform.position, carSpot.selfTransform.rotation, Cross.actors[0].transform, carSpot.directions);
                car.name = ((int)carSpot.position).ToString();
                ProcessingSignals.Default.Send(new SignalSetCarPosition((int)carSpot.position, car.GetComponent<ActorCar>()));
            }
            SetPlayer(Toolbox.Get<ProcessingPositions>().dataCarsLocation.positions.Random());
        }

        void SetPlayer(Actor player)
        {
            player.tags.Add(Tag.PlayerCar);
            player.selfTransform.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
        }
    }
}
