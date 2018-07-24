using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    [Serializable]
    class LVLCross :Homebrew.Starter
    {
        [FoldoutGroup("SetupData")] public List<FactorySituation> factorySituations;
        protected override void Setup()
        {
            Toolbox.Add<DataArtSession>();
            Toolbox.Add<ProcessingRoadData>();
            ProcessingPositions.Default = Toolbox.Add<ProcessingPositions>();
            Toolbox.Add<ProcessingPriority>();
            Toolbox.Add<ProcessingSpawn>();
            Toolbox.Add<ProcessingCamera>();
            Toolbox.Add<ProcessingQuiz>();
            ProcessingDespawn.Default =Toolbox.Add<ProcessingDespawn>();
            Toolbox.Add<ProcessingAnimation>();
            ProcessingStaticPositions.Default = Toolbox.Add<ProcessingStaticPositions>();
            ProcessingStaticPositions.Default.staticSituations = factorySituations;
            #region MainScript
            //Main enter spot of all sistems
            Toolbox.Add<ProcessingMainSсript>();
            #endregion
        }
    }
}
