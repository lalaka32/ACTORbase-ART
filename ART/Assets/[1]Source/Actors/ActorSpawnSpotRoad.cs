using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    class ActorSpawnSpotRoad : Actor
    {
        [FoldoutGroup("SpawnSpots")] public DataCarSpot spotOfCar;
        [FoldoutGroup("SpawnSpots")] public DataSignSpot spotOfSign;
        [FoldoutGroup("SpawnSpots")] public DataTrafficLightSpot spotOfTrafficLight;
        [FoldoutGroup("SpawnSpots")] public DataPosition position;

        protected override void SetupBehaviors()
        {

        }

        protected override void SetupData()
        {
            Add(position);
            Add(spotOfCar);
            Add(spotOfSign);
            Add(spotOfTrafficLight);

            tags.Add(Tag.SpawnSpotsRoad);
        }
    }
}
