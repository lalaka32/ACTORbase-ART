using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using FastDeb;
using Homebrew;

namespace BeeFly
{
    public static class TrafficLight
    {
        [TagField(categoryName = "Default")]
        public const int Empty = 0;
        [TagField(categoryName = "TrafficLight")]
        public const int Off = 1;
        [TagField(categoryName = "TrafficLight")]
        public const int Red = 2;
        [TagField(categoryName = "TrafficLight")]
        public const int Green = 3;
    }
}
