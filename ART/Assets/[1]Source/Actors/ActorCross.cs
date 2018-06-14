using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    public class ActorCross : Actor,ITick
    {
        [FoldoutGroup("SpawnSpots")] public DataSpotOfCars SpotsOfCars;
        [FoldoutGroup("SpawnSpots")] public DataSpotTrafficSign SpotsOfSigns;
        [FoldoutGroup("SpawnSpots")] public DataSpotTrafficLight SpotsOfTrafficLight;

        public DataCarsLocation dataCarsLocation;

        protected override void Setup()
        {
            Add(SpotsOfCars);
            Add(SpotsOfSigns);
            Add(SpotsOfTrafficLight);

            Add(dataCarsLocation);

            //Add<BehaviorTest>();
            Add<BehaviorMove>();

            tags.Add(Tag.Cross);
        }
    }
}
