using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    class ActorRoadSpot : Actor
    {
        [FoldoutGroup("SpawnSpots")] public DataCarSpot spotOfCar;
        [FoldoutGroup("SpawnSpots")] public DataSignSpot spotOfSign;
        [FoldoutGroup("SpawnSpots")] public DataTrafficLightSpot spotOfTrafficLight;

        protected override void Setup()
        {
            Add(spotOfCar);
            Add(spotOfSign);
            Add(spotOfTrafficLight);

            tags.Add(Tag.RoadSpot);
        }
    }
}
