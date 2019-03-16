using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    //Из-за сложных сязей решал сделать что-то вроде центра где будут посылаться сигналы "делай то сё"
    class ProcessingMainSсript : ProcessingBase , IReceive<SignalRespawn>, IMustBeWipedOut
    {
        public ProcessingMainSсript()
        {
           Homebrew.Timer.Add(0.1f,()=> PlayMainScript());
        }
        void PlayMainScript()
        {
            ProcessingSignals.Default.Send(new SignalSetCrossData(ProcessingStaticPositions.Default.Get(Situations.TestHotBug)));
            ProcessingStaticPositions.Default.SetTypeOfCross(TypeOfCross.Qvalent);
            //ProcessingSignals.Default.Send(new SignalGenerateCrossSituation(Toolbox.Get<DataArtSession>().typeOfCross));
            ProcessingSignals.Default.Send(new SignalSetSituations(Toolbox.Get<DataArtSession>().CrossSituation));
            ProcessingSignals.Default.Send(new SignalSpawn(Toolbox.Get<DataArtSession>().CrossSituation));
            ProcessingSignals.Default.Send(new SignalSetCamera());
            ProcessingSignals.Default.Send(new SignalSetComperativePositions());
            Homebrew.Timer.Add(0.1f, () => ProcessingSignals.Default.Send(new SignalSetPriority(Toolbox.Get<DataArtSession>().typeOfCross)));
        }
        public void HandleSignal(SignalRespawn arg)
        {
            ProcessingSignals.Default.Send(new SignalDespawn());
            ProcessingSignals.Default.Send(new SignalSetCrossData(ProcessingStaticPositions.Default.Get(Situations.TestHotBug)));
            //ProcessingSignals.Default.Send(new SignalGenerateCrossSituation(Toolbox.Get<DataArtSession>().typeOfCross));
            ProcessingStaticPositions.Default.SetTypeOfCross(TypeOfCross.Qvalent);
            ProcessingSignals.Default.Send(new SignalSetSituations(Toolbox.Get<DataArtSession>().CrossSituation));
            ProcessingSignals.Default.Send(new SignalSpawn(Toolbox.Get<DataArtSession>().CrossSituation));
            ProcessingSignals.Default.Send(new SignalSetCamera());
            ProcessingSignals.Default.Send(new SignalNextRound());
            ProcessingSignals.Default.Send(new SignalSetComperativePositions());
            Homebrew.Timer.Add(0.1f, () => ProcessingSignals.Default.Send(new SignalSetPriority(Toolbox.Get<DataArtSession>().typeOfCross)));
        }
    }
}
