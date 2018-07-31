using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
namespace BeeFly
{
    class TypeOfCross
    {
        [TagField(categoryName = "Type")]
        public const int Qvalent = 0;
        [TagField(categoryName = "Type")]
        public const int UnQvalent = 1;
        [TagField(categoryName = "Type")]
        public const int Regularity = 2;
    }
}
