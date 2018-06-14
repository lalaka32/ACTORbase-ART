using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    [Serializable]
    public class DataCarsLocation : IData
    {
        public Dictionary<int, Actor> positions = new Dictionary<int, Actor>();
        public void Dispose(){}
    }
}
