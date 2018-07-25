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
           Homebrew.Timer.Add(0.25f,()=> PlayMainScript());
        }
        void PlayMainScript()
        {
            ProcessingSignals.Default.Send(new SignalSetRoadData());
            ProcessingSignals.Default.Send(new SignalInitialSpawn());
            ProcessingSignals.Default.Send(new SignalSetCamera());
            ProcessingSignals.Default.Send(new SignalSetComperativePositions());
            Homebrew.Timer.Add(0.25f, () => ProcessingSignals.Default.Send(new SignalSetPriority()));
        }
        public void HandleSignal(SignalRespawn arg)
        {
            ProcessingSignals.Default.Send(new SignalDespawn());
            ProcessingSignals.Default.Send(new SignalSetRoadData());
            ProcessingSignals.Default.Send(new SignalSpawnCars());
            ProcessingSignals.Default.Send(new SignalSetCamera());
            ProcessingSignals.Default.Send(new SignalNextRound());
            ProcessingSignals.Default.Send(new SignalSetComperativePositions());
            Homebrew.Timer.Add(0.25f, () => ProcessingSignals.Default.Send(new SignalSetPriority()));
        }
    }
}
