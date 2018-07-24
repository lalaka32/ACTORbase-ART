using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class ComponentTrafficSign : MonoCached
    {
        protected override void HandleEnable()
        {
            ProcessingSignals.Default.Add(this);
            ProcessingDespawn.Default.Add(this);
        }
    }
}
