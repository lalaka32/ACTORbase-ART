﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    struct SignalSetPriority
    {
        public int typeOfCross;

        public SignalSetPriority(int typeOfCross)
        {
            this.typeOfCross = typeOfCross;
        }
    }
}
