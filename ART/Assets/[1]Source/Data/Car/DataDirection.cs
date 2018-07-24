using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    [Serializable]
    public class DataDirection : IData
    {
        [TagFilter(typeof(Direction))] public int direction;

        public DataDirection(int direction)
        {
            this.direction = direction;
        }
        public DataDirection()
        {

        }
        public void Dispose(){}
    }
}
