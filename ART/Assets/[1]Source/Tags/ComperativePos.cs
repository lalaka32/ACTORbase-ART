using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    static class ComperativePos
    {
        [TagField(categoryName = "ComperativePosition/Right")]
        public const int Right = 0;
        [TagField(categoryName = "ComperativePosition/Front")]
        public const int Front = 1;
        [TagField(categoryName = "ComperativePosition/Left")]
        public const int Left = 2;
    }
}
