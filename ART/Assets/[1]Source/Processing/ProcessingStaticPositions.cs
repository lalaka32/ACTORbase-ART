using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    class ProcessingStaticPositions : ProcessingBase, IMustBeWipedOut
    {
        public static ProcessingStaticPositions Default;

        public List<FactorySituation> staticSituations;

        public List<Situation> Get(int tag)
        {
            foreach (var item in staticSituations)
            {
                if (item.tagSituation == tag)
                {
                    return item.Cases;
                }
            }
            return null;
        }
    }
}
