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
            Toolbox.Add<DataArtSession>();
            Toolbox.Add<ProcessingRoadData>();
            Toolbox.Add<ProcessingPositions>();
            Toolbox.Add<ProcessingPriority>();
            Toolbox.Add<ProcessingSpawn>();
            Toolbox.Add<ProcessingCamera>();
            Toolbox.Add<ProcessingQuiz>();
            Toolbox.Add<ProcessingDespawn>();
            Toolbox.Add<ProcessingAnimation>();

            #region MainScript
            //Main enter spot of all sistems
            Toolbox.Add<ProcessingMainSсript>();
            #endregion
        }
    }
}
