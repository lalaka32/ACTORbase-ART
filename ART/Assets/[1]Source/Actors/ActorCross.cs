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
        [FoldoutGroup("Setup")] public List<DataSpot> SpotsOfCars;
        [FoldoutGroup("Setup")] public List<DataSpot> SpotsOfSigns;
        [FoldoutGroup("Setup")] public List<DataSpot> SpotsOfTrafficLight;

        protected override void Setup()
        {
            foreach (DataSpot item in SpotsOfCars)
            {
                Add(item);
            }
        }
    }
}
