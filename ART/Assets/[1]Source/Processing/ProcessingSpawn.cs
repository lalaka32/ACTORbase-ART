﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;
using FastDeb;

namespace BeeFly
{
    class ProcessingSpawn : ProcessingBase, IMustBeWipedOut, IReceive<SignalSpawn>
    {
        //Сделать чтобы заддные задосились куда то в процессинг спавн а затем только спавнить, а то этот
        //Обработчик смахивает на мусорку

        [GroupBy(Tag.Cross)]
        Group cross;

        [GroupBy(Tag.SpawnSpotsRoad)]
        Group spawnSpotsRoad;

        public void HandleSignal(SignalSpawn arg)
        {
            foreach (var situation in arg.posInfo)
            {
                foreach (var spawnSpot in spawnSpotsRoad.actors)
                {
                    if (situation.position == spawnSpot.Get<DataPosition>().position)
                    {
                        Spawn(situation,spawnSpot);
                    }
                }
            }
        }
        void Spawn( Situation sit , Actor spawnSpot)
        {
            if (sit.car)
            {
                SpawnCar(spawnSpot, ref sit.actorCar, sit.direction.direction);
                if (sit.player)
                {
                    SetPlayer(sit.actorCar);
                }
            }
            switch (sit.trafficLight)
            {
                case TrafficLight.Off:
                    SpawnTL(spawnSpot).GetComponent<ComponentTrafficLight>().signals.Send(new SignalSetColor(Color.yellow));
                    break;
                case TrafficLight.Red:
                    SpawnTL(spawnSpot).GetComponent<ComponentTrafficLight>().signals.Send(new SignalSetColor(Color.red));
                    break;
                case TrafficLight.Green:
                    SpawnTL(spawnSpot).GetComponent<ComponentTrafficLight>().signals.Send(new SignalSetColor(Color.green));
                    break;
                case TrafficLight.Empty:
                    break;
                default:
                    break;
            }
            switch (sit.trafficSign)
            {
                case TrafficSign.Main:
                    SpawnMainSign(spawnSpot);
                    break;
                case TrafficSign.Secondary:
                    SpawnSecondarySign(spawnSpot);
                    break;
                case TrafficSign.Empty:
                    break;
                default:
                    break;
            }
        }
        Transform SpawnTL(Actor roadSpot)
        {
            var trafficLight = roadSpot.Get<DataTrafficLightSpot>().trafficLightSpot.selfTransform;
            return Toolbox.Get<FactoryRoad>().Spawn(trafficLight.position, trafficLight.rotation, Tag.TrafficLight, cross.actors[0].transform.Find("Lights"));
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

        void SpawnCar(Actor roadSpot, ref ActorCar actorCar, int direction)
        {
            var carSpot = roadSpot.Get<DataCarSpot>().carSpot;
            var car = Toolbox.Get<FactoryCar>().SpawnCar(carSpot.selfTransform.position, carSpot.selfTransform.rotation, cross.actors[0].selfTransform,Tag.SkateBoard);
            car.name = (roadSpot.Get<DataPosition>().position).ToString();
            actorCar = car.GetComponent<ActorCar>();
            actorCar.Get<DataDirection>().direction = direction;
            Homebrew.Timer.Add(0.1f, () => car.GetComponent<ActorCar>().GetComponent<ActorCar>().signals.Send(new SignalSetLights()));
        }

        void SetPlayer(Actor player)
        {
            player.selfTransform.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
            player.tags.Add(Tag.PlayerCar);
        }
    }
}
