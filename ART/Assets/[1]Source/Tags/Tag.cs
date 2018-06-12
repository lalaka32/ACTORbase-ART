using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    public static partial class Tag
    {
        [TagField(categoryName = "SpawnPoints")]
        public const int Cross = 1;

        [TagField(categoryName = "Cross")]
        public const int CarPosition = 2;
        [TagField(categoryName = "Cross")]
        public const int TLPosition = 3;
        [TagField(categoryName = "Cross")]
        public const int SignPosition = 4;

        [TagField(categoryName = "Cross/SpawnPointsCar")]//тэги для 4-х позиций
        public const int FirstPositionOfCar = 10;//если перецк больше чем однопол то хз
        [TagField(categoryName = "Cross/SpawnPointsCar")]//наверн нужно 1 тэг но тогда не 
        public const int SecondPositionOfCar = 11;//будет доступа к конкретной позиции пока хз
        [TagField(categoryName = "Cross/SpawnPointsCar")]
        public const int ThirtPositionOfCar = 12;//Неуверен нужны ли они ваще
        [TagField(categoryName = "Cross/SpawnPointsCar")]
        public const int ForthPositionOfCar = 13;

        [TagField(categoryName = "Cross/SpawnPointsTL")]
        public const int FirstPositionOfTrafficLight = 21;
        [TagField(categoryName = "Cross/SpawnPointsTL")]
        public const int SecondPositionOfTrafficLight = 22;
        [TagField(categoryName = "Cross/SpawnPointsTL")]
        public const int ThirtPositionOfTrafficLight = 23;
        [TagField(categoryName = "Cross/SpawnPointsTL")]
        public const int ForthPositionOfTrafficLight = 24;

        [TagField(categoryName = "Cross/SpawnPointsSign")]
        public const int FirstPositionOfSign = 31;
        [TagField(categoryName = "Cross/SpawnPointsSign")]
        public const int SecondPositionOfSign = 32;
        [TagField(categoryName = "Cross/SpawnPointsSign")]
        public const int ThirtPositionOfSign = 33;
        [TagField(categoryName = "Cross/SpawnPointsSign")]
        public const int ForthPositionOfSign = 34;
    }
}
