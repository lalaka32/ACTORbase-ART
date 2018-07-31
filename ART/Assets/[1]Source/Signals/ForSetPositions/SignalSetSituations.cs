using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;
using FastDeb;

namespace BeeFly
{
    struct SignalSetSituations
    {
        public List<Situation> situations;
        public SignalSetSituations(List<Situation> list = null)
        {
            situations = list;
        }
    }
}
