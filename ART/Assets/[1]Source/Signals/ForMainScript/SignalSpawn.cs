﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    struct SignalSpawn
    {
        public Dictionary<int, Situation> posInfo;

        public SignalSpawn(Dictionary<int, Situation> posInfo)
        {
            this.posInfo = posInfo;
        }
    }
}
