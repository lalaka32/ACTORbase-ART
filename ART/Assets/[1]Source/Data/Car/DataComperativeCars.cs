using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    [Serializable]
    public class DataComperativeCars : IData
    {
        public Dictionary<int, Actor> comperative = new Dictionary<int, Actor>();
        public void Dispose()
        {
            comperative = null;
        }
    }
}
