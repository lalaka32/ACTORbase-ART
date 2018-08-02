using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BeeFly;

public class RoadSituation
{
    public RoadSituation(int countOfCars, PositionRotation[] posRotAnimCar, bool vIP, Direction[] directions,
        int trafficSign, int coutOfSigns, PositionRotation[] posRotSign,
        int trafficLight, int coutOfLights, PositionRotation[] posRotLight)
    {
        CountOfCars = countOfCars;
        this.posRotAnimCar = posRotAnimCar;
        VIP = vIP;
        this.directions = directions;
        this.trafficSign = trafficSign;
        CountOfSigns = coutOfSigns;
        this.posRotSign = posRotSign;
        this.trafficLight = trafficLight;
        CoutOfLights = coutOfLights;
        this.posRotLight = posRotLight;
    }
    public RoadSituation()
    {

    }
    public int CountOfCars { get; private set; }
    public PositionRotation[] posRotAnimCar { get; private set; }
    public bool VIP { get; private set; }
    public Direction[] directions { get; private set; }

    public int trafficSign { get; private set; }
    public int CountOfSigns { get; private set; }
    public PositionRotation[] posRotSign { get; private set; }

    public int trafficLight { get; private set; }
    public int CoutOfLights { get; private set; }
    public PositionRotation[] posRotLight { get; private set; }
}

