using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    class BehaviorPriority : Behavior
    {
        //есть идея не вписывать разделять наши правили а просто добавлять доп правила при
        //условиях типа есть TL есть Sign

        [Bind] DataPriority priority;
        void SetPriority()
        {

        }
    }
}
