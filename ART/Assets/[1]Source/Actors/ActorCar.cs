using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    class ActorCar : Actor
    {
        //бля я падумал было бы прикольна менять приритет динамиески
        //типо стоит на светофоре на зелёном прошоло там 10 сек он уже переключился на красный
        //а плеер стоит и он обратно и чтобы у него были разные приоры при разном свете)))
        //Ещё добавить при столкновении тряку экрана
        protected override void Setup()
        {
            
        }
    }
}
