using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    class Situations
    {
        [TagField(categoryName = "Defoult")]
        public const int None = 0;

        [TagField(categoryName = "SignOnly")]
        public const int UnequalRightAngle = 1;
        [TagField(categoryName = "SignOnly")]
        public const int UnequalRightAngleMirror = 2;

        [TagField(categoryName = "TrafficLightOnly")]
        public const int RegularityRightAngle = 3;
        [TagField(categoryName = "TrafficLightOnly")]
        public const int RegularityRightAngleMirror = 4;

        [TagField(categoryName = "Test")]
        public const int TestRightHindrence = 5;
    }
}
