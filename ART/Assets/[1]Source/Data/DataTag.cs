using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    [System.Serializable]
    struct DataTag
    {
        [TagFilter(typeof(Tag))] public int id;
    }
}
