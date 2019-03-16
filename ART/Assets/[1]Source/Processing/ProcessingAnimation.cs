using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class ProcessingAnimation : ProcessingBase, IMustBeWipedOut, IReceive<SignalAnimationStage>,IReceive<SignalCarAnimationTurnFinished>,IReceive<SignalSwitchFinished>
    {
        [GroupBy(Tag.Car)]
        Group cars;
        bool switched = false;
        int currentPriority = 0;
        int maxPriority;
        
        public void HandleSignal(SignalAnimationStage arg)
        {
            Debug.Log("SignalAnimationStage");
            currentPriority = 0;
            maxPriority = Toolbox.Get<DataArtSession>().GetMaxPriority();
            HandlePrioty(currentPriority);
        }

        public void HandleSignal(SignalSwitchFinished arg)
        {
            Debug.Log("SignalSwitchFinished");
            
            HandlePrioty(currentPriority);
        }

        public void HandleSignal(SignalCarAnimationTurnFinished arg)
        {
            Debug.Log("------------------finished------------");
            currentPriority++;
            
            HandlePrioty(currentPriority);
        }
        void HandlePrioty(int priority)
        {
            if (priority > maxPriority)
                return;
            Debug.Log("curr" + currentPriority);
            if (Toolbox.Get<DataArtSession>().typeOfCross == TypeOfCross.Regularity)
            {
                //Debug.Log(Toolbox.Get<DataArtSession>().GetSituation(position).trafficLight);
                Debug.Log(Toolbox.Get<DataArtSession>().IsGreen(priority)+" y "+ priority);
                foreach (var item in Toolbox.Get<DataArtSession>().CrossSituation)
                {
                    Debug.Log("pos : "+item.position+"TL : "+ item.trafficLight);
                }
                if (!Toolbox.Get<DataArtSession>().IsGreen(priority))
                {
                    ProcessingSignals.Default.Send(new SignalTougleColor());
                    return;
                    //HandleAnimations(Toolbox.Get<DataArtSession>().GetCars(priority));
                }
            }
            HandleAnimations(Toolbox.Get<DataArtSession>().GetCars(priority));
        }

        private void HandleAnimations(List<Actor> cars)
        {
            foreach (var car in cars)
            {
                car.signals.Send(new SignalPlayCarAnimation());
            }
        }
    }
}
