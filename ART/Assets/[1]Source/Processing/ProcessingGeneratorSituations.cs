﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BeeFly
{
    class ProcessingGeneratorSituations : ProcessingBase, IReceive<SignalGenerateCrossSituation>, IMustBeWipedOut
    {
        public List<Situation> generatedSituations;

        [GroupBy(Tag.SpawnSpotsRoad)]
        Group spawnSpotsRoad;

        public void HandleSignal(SignalGenerateCrossSituation arg)
        {
            generatedSituations = new List<Situation>(Toolbox.Get<DataArtSession>().MaxCars);
            for (int iPosition = 0; iPosition < Toolbox.Get<DataArtSession>().MaxCars; iPosition++)
            {
                generatedSituations.Add(new Situation(null, TrafficLight.Empty, TrafficSign.Empty, iPosition));
            }
            GenerateCars(Toolbox.Get<DataArtSession>().countOfCars);

            switch (arg.TypeOfCross)
            {
                case TypeOfCross.Regularity:
                    MergeSituations(generatedSituations, ProcessingStaticPositions.Default.GetRandom(Situations.RegularityRightAngle, Situations.RegularityRightAngleMirror), Filter.TrafficLight);
                    break;
                case TypeOfCross.UnQvalent:
                    MergeSituations(generatedSituations, ProcessingStaticPositions.Default.GetRandom(Situations.UnequalRightAngle,Situations.UnequalRightAngleMirror), Filter.TrafficSign);
                    break;
            }
            Toolbox.Get<DataArtSession>().CrossSituation = generatedSituations;
        }
        public void GenerateCars(int countOfCars)
        {
            var spawnSpotsShaffled = spawnSpotsRoad.actors.Shaffle();
            for (int i = 0; i < countOfCars; i++)
            {
                Actor randomSpot = spawnSpotsShaffled[i].GetComponent<ActorSpawnSpotRoad>();
                generatedSituations[randomSpot.Get<DataPosition>().position].car = true;
                generatedSituations[randomSpot.Get<DataPosition>().position].direction = randomSpot.Get<DataPossibleDirections>().possibleDirections.ReturnRandom();
            }
            generatedSituations[spawnSpotsShaffled[Random.Range(0, countOfCars)].Get<DataPosition>().position].player = true;
        }
        List<Situation> MergeSituations(List<Situation> before, List<Situation> toMerge, Filter filter)
        {
            foreach (var iSituation in before)
            {
                foreach (var jSituation in toMerge)
                {
                    if (iSituation.position == jSituation.position)
                    {
                        switch (filter)
                        {
                            case Filter.TrafficSign:
                                iSituation.trafficSign = jSituation.trafficSign;
                                break;
                            case Filter.TrafficLight:
                                iSituation.trafficLight = jSituation.trafficLight;
                                break;
                        }
                    }
                }
            }
            return before;
        }

        enum Filter
        {
            TrafficSign, TrafficLight
        }
    }
}
