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
        [FoldoutGroup("SetupRoad")] public List<FactorySituation> factorySituations;

        [FoldoutGroup("SetupRoad")] public RulesForCross Rules4Qvalent;

        [FoldoutGroup("SetupRoad")] public RulesForCross Rules4UnQvalent;

        [FoldoutGroup("SetupRoad")] public RulesForCross Rules4Regularity;

        protected override void Setup()
        {
            Toolbox.Add<DataArtSession>();
            Toolbox.Add<ProcessingRoadData>();
            Toolbox.Add<ProcessingPriority>();
            Toolbox.Add<ProcessingSpawn>();
            Toolbox.Add<ProcessingCamera>();
            Toolbox.Add<ProcessingQuiz>();
            Toolbox.Add<ProcessingAnimation>();

            ProcessingPositions.Default = Toolbox.Add<ProcessingPositions>();
            ProcessingDespawn.Default = Toolbox.Add<ProcessingDespawn>();
            ProcessingStaticPositions.Default = Toolbox.Add<ProcessingStaticPositions>();
            ProcessingPriority.Default = Toolbox.Add<ProcessingPriority>();

            ProcessingStaticPositions.Default.staticSituations = factorySituations;
            ProcessingPriority.Default.RulesForQvalent = Rules4Qvalent;
            ProcessingPriority.Default.RulesForUnQvalent = Rules4UnQvalent;
            ProcessingPriority.Default.RulesForRegularity = Rules4Regularity;
            #region MainScript
            //Main enter spot of all sistems
            Toolbox.Add<ProcessingMainSсript>();
            #endregion
        }
    }
}
