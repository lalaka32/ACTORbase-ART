using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    class LVLCross :Homebrew.Starter
    {
        protected override void Setup()
        {
            //RoadData должна быт 1-я
            //Prioryty перед спавн
            Toolbox.Add<DataArtSession>();
            Toolbox.Add<ProcessingRoadData>();
            Toolbox.Add<ProcessingPositions>();
            Toolbox.Add<ProcessingPriority>();
            Toolbox.Add<ProcessingSpawn>();
            Toolbox.Add<ProcessingCamera>();
            Toolbox.Add<ProcessingQuiz>();
            Toolbox.Add<ProcessingDespawn>();
            Toolbox.Add<ProcessingMainSсript>();
        }
    }
}
