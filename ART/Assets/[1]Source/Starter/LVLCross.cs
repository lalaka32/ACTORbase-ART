using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    class LVLCross :Homebrew.Starter
    {
        protected override void Setup()
        {
            Homebrew.Toolbox.Add<ProcessingSpawn>();
        }
    }
}
