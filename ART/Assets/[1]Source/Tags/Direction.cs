using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    public class Direction
    {
        [TagField(categoryName = "Direction")]
        public const int Right = 0;
        [TagField(categoryName = "Direction")]
        public const int Forward = 1;
        [TagField(categoryName = "Direction")]
        public const int Left = 2;
    }
}
