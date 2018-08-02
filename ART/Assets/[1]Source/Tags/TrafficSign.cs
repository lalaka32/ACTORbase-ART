using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;
using FastDeb;

namespace BeeFly
{
    public static class TrafficSign
    {
        [TagField(categoryName = "Default")]
        public const int Empty = 0;
        [TagField(categoryName = "TrafficSign")]
        public const int Main = 1;
        [TagField(categoryName = "TrafficSign")]
        public const int Secondary = 2;
    }
}
