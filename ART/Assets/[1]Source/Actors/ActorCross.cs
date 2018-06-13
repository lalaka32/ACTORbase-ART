using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    class ActorCross : Actor
    {
        [FoldoutGroup("Setup")] public DataSpotOfCars SpotsOfCars;
        [FoldoutGroup("Setup")] public DataSpotTrafficSign SpotsOfSigns;
        [FoldoutGroup("Setup")] public DataSpotTrafficLight SpotsOfTrafficLight;

        protected override void Setup()
        {

            Add(SpotsOfCars);
            Add(SpotsOfSigns);
            Add(SpotsOfTrafficLight);

            tags.Add(Tag.OneLane);
        }
    }
}
