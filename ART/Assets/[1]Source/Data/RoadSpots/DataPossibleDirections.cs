using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    [Serializable]
    class DataPossibleDirections :IData
    {
        public List<DataDirection> possibleDirections = new List<DataDirection>();

        public void Dispose()
        {
            possibleDirections = null;
        }
    }
}
