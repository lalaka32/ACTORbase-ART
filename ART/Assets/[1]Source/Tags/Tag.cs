﻿using System;
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
        public const int SpawnerOfCross = 1;

        [TagField(categoryName = "Cross")]
        public const int CarPosition = 2;
        [TagField(categoryName = "Cross")]
        public const int TLPosition = 3;
        [TagField(categoryName = "Cross")]
        public const int SignPosition = 4;
        
        //их всех нужно объеденить мб типо slot 1 
        //а там будет и машина и светофор и знак
        //и всё что нам ещё нужно

        [TagField(categoryName = "Cross/SpawnPointsCar")]//тэги для 4-х позиций
        public const int FirstPositionOfCar = 10;//если перецк больше чем однопол то хз
        [TagField(categoryName = "Cross/SpawnPointsCar")]//наверн нужно 1 тэг но тогда не 
        public const int SecondPositionOfCar = 11;//будет доступа к конкретной позиции пока хз
        [TagField(categoryName = "Cross/SpawnPointsCar")]
        public const int ThirtPositionOfCar = 12;//Неуверен нужны ли они ваще
        [TagField(categoryName = "Cross/SpawnPointsCar")]
        public const int ForthPositionOfCar = 13;

        //Это мб пригодится для выборки наших светофоров 
        [TagField(categoryName = "Cross/SpawnPointsTL")]
        public const int FirstPositionOfTrafficLight = 21;
        [TagField(categoryName = "Cross/SpawnPointsTL")]
        public const int SecondPositionOfTrafficLight = 22;
        [TagField(categoryName = "Cross/SpawnPointsTL")]
        public const int ThirtPositionOfTrafficLight = 23;
        [TagField(categoryName = "Cross/SpawnPointsTL")]
        public const int ForthPositionOfTrafficLight = 24;

        //Это мб пригодится для выборки наших знаков 
        [TagField(categoryName = "Cross/SpawnPointsSign")]
        public const int FirstPositionOfSign = 31;
        [TagField(categoryName = "Cross/SpawnPointsSign")]
        public const int SecondPositionOfSign = 32;
        [TagField(categoryName = "Cross/SpawnPointsSign")]
        public const int ThirtPositionOfSign = 33;
        [TagField(categoryName = "Cross/SpawnPointsSign")]
        public const int ForthPositionOfSign = 34;

        [TagField(categoryName = "Cross/TypeOfCross")]
        public const int OneLane = 41;
        [TagField(categoryName = "Cross/TypeOfCross")]
        public const int TwoLane = 42;
        [TagField(categoryName = "Cross/TypeOfCross")]
        public const int ThreeLane = 43;
        [TagField(categoryName = "Cross/TypeOfCross")]
        public const int RoundLane = 44;

        [TagField(categoryName = "Car/Directions")]
        public const int DirectionRight = 51;
        [TagField(categoryName = "Car/Directions")]
        public const int DirectionForward = 52;
        [TagField(categoryName = "Car/Directions")]
        public const int DirectionLeft = 53;
        [TagField(categoryName = "Car/Directions")]
        public const int DirectionTurn = 54;
        [TagField(categoryName = "Car/Directions")]
        public const int DirectionNone = 55;

        [TagField(categoryName = "Entity")]
        public const int PlayerCar = 60;
        [TagField(categoryName ="Entity")]
        public const int Car = 61;
        [TagField(categoryName = "Entity")]
        public const int VIP = 62;
        [TagField(categoryName = "Entity")]
        public const int Cross = 63;
    }
}
