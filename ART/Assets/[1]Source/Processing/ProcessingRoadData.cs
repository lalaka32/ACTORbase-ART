using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BeeFly
{
    class ProcessingRoadData : ProcessingBase, IMustBeWipedOut, IReceive<SignalSetCrossData>
    {
        public void HandleSignal(SignalSetCrossData arg)
        {
            DataChances DataChances = Toolbox.Get<DataChances>();
            Toolbox.Get<DataArtSession>().SetRoadData(RollTypeOfCross(DataChances), RollCountOfCars(DataChances));
        }
        int RollTypeOfCross(DataChances dataChances)
        {
            if (Roll(dataChances.chanceOfQvalent))
            {
                return TypeOfCross.Qvalent;
            }
            else if(Roll(dataChances.chanceOfUnQvalent))
            {
                return TypeOfCross.UnQvalent;
            }
            else if(Roll(dataChances.chanceOfRegularity))
            {
                return TypeOfCross.Regularity;
            }
            else
            {
                return dataChances.defaultType;
            }
        }
        bool Roll(int chance)
        {
            return Random.Range(0, 101) < chance;
        }
        int RollCountOfCars(DataChances dataChances)
        {
            return Random.Range(dataChances.MinToRandom, dataChances.MaxToRandom);
        }
    }
}
