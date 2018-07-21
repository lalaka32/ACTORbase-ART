using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    public partial class Tag
    {
        [TagField(categoryName = "Cross/SpawnPointsCar")]//тэги для 4-х позиций
        public const int FirstPositionOfCar = 10;//если перецк больше чем однопол то хз
        [TagField(categoryName = "Cross/SpawnPointsCar")]//наверн нужно 1 тэг но тогда не 
        public const int SecondPositionOfCar = 11;//будет доступа к конкретной позиции пока хз
        [TagField(categoryName = "Cross/SpawnPointsCar")]
        public const int ThirtPositionOfCar = 12;//Неуверен нужны ли они ваще
        [TagField(categoryName = "Cross/SpawnPointsCar")]
        public const int ForthPositionOfCar = 13;


        
    }
}
