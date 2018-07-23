using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    [Serializable]
    public class DataPosition : IData
    {
        [TagFilter(typeof(Position))] public int position;

        public void Dispose(){}
    }
}
