using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    struct SignalSetCrossData
    {
        public List<Situation> list;
        
        public SignalSetCrossData(List<Situation> list)
        {
            this.list = list;
        }
    }
}
