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
            Toolbox.Add<ProcessingRoadData>();
            Toolbox.Add<ProcessingSpawn>();
            Toolbox.Add<ProcessingPositions>();
            Toolbox.Add<ProcessingCamera>();
            Toolbox.Add<ProcessingQuiz>();
            Toolbox.Add<ProcessingDespawn>();
        }
    }
}
