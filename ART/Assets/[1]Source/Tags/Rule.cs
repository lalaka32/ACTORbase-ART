using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    public class Rule 
    {
        [TagField(categoryName = "Rule")]
        public const int None = 0;

        [TagField(categoryName = "Rule")]
        public const int HindranceRight = 1;
        [TagField(categoryName = "Rule")]
        public const int HindranceForward = 2;
    }
}
