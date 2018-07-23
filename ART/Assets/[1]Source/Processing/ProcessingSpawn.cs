using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;
using FastDeb;

namespace BeeFly
{
    class ProcessingSpawn : ProcessingBase, IMustBeWipedOut, IReceive<SignalSpawnCars>, IReceive<SignalInitialSpawn>
    {

        [GroupBy(Tag.Cross)]
        Group cross;

        [GroupBy(Tag.SpawnSpotsRoad)]
        Group spawnSpotsRoad;

        public void HandleSignal(SignalInitialSpawn arg)
        {
            Spawn();
        }

        void Spawn()
        {
            var sit = ProcessingStaticPositions.Default.Get(Situations.UnequalRightAngleMirror);
            for (int i = 0; i < sit.Count; i++)
            {
                SpawnStatic(sit[i]);
                //SpawnTL(RoadSpots.actors[i]);
                //SpawnSign(RoadSpots.actors[i]);
            }
            SpawnCars();

        }
        public void SpawnStatic(Situation situation)
        {
            foreach (var item in spawnSpotsRoad.actors)
            {
                if (item.Get<DataPosition>().position == situation.position)
                {
                    switch (situation.trafficSign)
                    {
                        case TrafficSign.Main:
                            SpawnMainSign(item);
                            break;
                        case TrafficSign.Secondary:
                            SpawnSecondarySign(item);
                            break;
                        case TrafficSign.Empty:
                            break;
                    }
                    switch (situation.trafficLight)
                    {
                        case TrafficLight.Off:
                            SpawnTL(item);
                            break;
                        case TrafficLight.Red:
                            SpawnTL(item);
                            break;
                        case TrafficLight.Green:
                            SpawnTL(item);
                            break;
                        case TrafficLight.Empty:
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        public void HandleSignal(SignalSpawnCars arg)
        {
            SpawnCars();
        }

        void SpawnTL(Actor roadSpot)
        {
            var trafficLight = roadSpot.Get<DataTrafficLightSpot>().trafficLightSpot.selfTransform;
            Toolbox.Get<FactoryRoad>().Spawn(trafficLight.position, trafficLight.rotation, Tag.TrafficLight, cross.actors[0].transform.Find("Lights"));
        }

        void SpawnMainSign(Actor roadSpot)
        {
            var signSpot = roadSpot.Get<DataSignSpot>().signSpot.selfTransform;
            Toolbox.Get<FactoryRoad>().Spawn(signSpot.position, signSpot.rotation, Tag.SignMain, cross.actors[0].transform.Find("Signs"));
        }
        void SpawnSecondarySign(Actor roadSpot)
        {
            var signSpot = roadSpot.Get<DataSignSpot>().signSpot.selfTransform;
            Toolbox.Get<FactoryRoad>().Spawn(signSpot.position, signSpot.rotation, Tag.SignSecondary, cross.actors[0].transform.Find("Signs"));
        }

        void SpawnCars()
        {
            List<Actor> actorShaffled = spawnSpotsRoad.actors.Shaffle();

            for (int i = 0; i < Toolbox.Get<DataArtSession>().dataRoadSituation.CountOfCars; i++)
            {
                var carSpot = actorShaffled[i].Get<DataCarSpot>().carSpot;
                var car = Toolbox.Get<FactoryCar>().SpawnCar(carSpot.selfTransform.position, carSpot.selfTransform.rotation, cross.actors[0].transform, carSpot.directions);
                car.name = (actorShaffled[i].Get<DataPosition>().position).ToString();
                ProcessingSignals.Default.Send(new SignalSetCarPosition(actorShaffled[i].Get<DataPosition>().position, car.GetComponent<ActorCar>()));
            }
            SetPlayer(ProcessingPositions.Default.dataCarsLocation.Random().car);
        }

        void SetPlayer(Actor player)
        {
            player.tags.Add(Tag.PlayerCar);
            player.selfTransform.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
        }
    }
}
