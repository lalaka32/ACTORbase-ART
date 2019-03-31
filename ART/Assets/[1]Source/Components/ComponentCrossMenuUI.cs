using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastDeb;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class ComponentCrossMenuUI : MonoCached
    {
        public void Restart()
        {
            Debug.Log("--------------------------------------------" + Toolbox.Get<DataArtSession>().NumberOfQuestion);
            ProcessingSignals.Default.Send(new SignalRespawn());
        }
        public void PlayAnimation()
        {
            ProcessingSignals.Default.Send(new SignalAnimationStage());
        }
        public void BackToMainMenu()
        {
            Scenes.MainMenu.To();
        }
    }
}
