using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class ComponentMenu : MonoCached
    {
        
        public void Restart()
        {
            Debug.Log("--------------------------------------------" + Toolbox.Get<DataArtSession>().NumberOfQuestion);
            ProcessingSignals.Default.Send(new SignalRespawn());
        }
    }
}
