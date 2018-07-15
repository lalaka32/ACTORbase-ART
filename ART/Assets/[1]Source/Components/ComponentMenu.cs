﻿using System;
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
            ProcessingSignals.Default.Send<SignalRespawn>();
        }
    }
}
