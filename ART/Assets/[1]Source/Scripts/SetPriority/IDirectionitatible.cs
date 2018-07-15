using System.Collections.Generic;
using Enums;
using Homebrew;

namespace BeeFly
{
    public interface IDirectionable
    {
        void SetPriority(DataComperativeCars comperative, Actor settingCar);
    }
}
