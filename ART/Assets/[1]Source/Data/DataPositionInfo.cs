﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    //[Serializable]
    //public class DataPositionInfo : IData
    //{
    //    public TrafficLight trafficLight;
    //    public TrafficSign trafficSign;
    //    public ActorCar car;

    //    public DataPositionInfo(ActorCar car = null, TrafficLight trafficLight =TrafficLight.Empty, TrafficSign trafficSign = TrafficSign.Empty)
    //    {
    //        SetData(car,trafficLight,trafficSign);
    //    }
    //    public void SetData(ActorCar car = null, TrafficLight trafficLight = TrafficLight.Empty, TrafficSign trafficSign = TrafficSign.Empty)
    //    {
    //        this.trafficLight = trafficLight;
    //        this.trafficSign = trafficSign;
    //        this.car = car;
    //    }
    //    public void Dispose()
    //    {
    //        car = null;
    //    }
    //}
    public enum TrafficLight : byte { Off = 0, Red, Green, Empty }
    public enum TrafficSign { Main, Secondary, Empty }//stop
}
