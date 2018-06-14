using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    [Serializable]
    public class DataPriority : IData
    {
        public int priority =0;

        public void Dispose(){}
    }
}
