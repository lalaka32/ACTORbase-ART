using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    [Serializable]
    class DataPosition : IData
    {
        public int position;

        public void Dispose(){}
    }
}
