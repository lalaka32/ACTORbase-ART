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
        //Это лист по спотами для спавна манин
        [FoldoutGroup("SpawnSpots")] public DataSpotOfCars SpotsOfCars;
        //Это лист по спотами для спавна знаков
        [FoldoutGroup("SpawnSpots")] public DataSpotTrafficSign SpotsOfSigns;
        //Это лист по спотами для спавна светофоров
        [FoldoutGroup("SpawnSpots")] public DataSpotTrafficLight SpotsOfTrafficLight;
        //Тут уже храним присутствующие машины
        public DataCarsLocation dataCarsLocation;

        protected override void Setup()
        {
            Add(SpotsOfCars);
            Add(SpotsOfSigns);
            Add(SpotsOfTrafficLight);

            Add(dataCarsLocation);

            tags.Add(Tag.Cross);
        }
    }
}
