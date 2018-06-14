using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    [Serializable]
    class DataDirection : IData
    {
        public int direction;
        public void Dispose(){}
    }
}
