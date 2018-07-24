using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class ProcessingPriority : ProcessingBase, IReceive<SignalSetPriority>, IMustBeWipedOut
    {
        public static ProcessingPriority Default;

        [GroupBy(Tag.Car)]
        Group cars;

        public List<FactoryRules> RulesForQvalent;

        public List<FactoryRules> RulesForUnQvalent;

        public List<FactoryRules> RulesForRegularity;

        public void HandleSignal(SignalSetPriority arg)
        {
            foreach (var car in cars.actors)
            {
                //car.signals.Send(new SignalSetPriority());
                Validation(car);
            }
        }
        void Validation(Actor settingCar)
        {
            foreach (var rule in RulesForQvalent)
            {
                bool validation = false;
                var settingComperative =settingCar.Get<DataComperativeCars>().comperative;
                foreach (var condition in rule.conditions)
                {
                    if (condition.car)
                    {
                        Actor observeCar;
                        if (settingComperative.TryGetValue(condition.comperativePosition, out observeCar))
                        {
                            if (condition.direction!=Direction.None)
                            {
                                if (settingCar.Get<DataDirection>().direction == condition.direction)
                                {
                                    validation = true;
                                }
                                else
                                {
                                    validation = false;
                                }
                            }
                            else
                            {
                                validation = false;
                            }
                        }
                        else
                        {
                            validation = false;
                        }
                    }
                    else
                    {
                        validation = false;
                    }
                }
                IncrementPrioriry(settingCar, validation);
            }
        }
        void IncrementPrioriry(Actor settingCar,bool Validation = true)
        {
            if (Validation)
            {
                settingCar.Get<DataPriority>().priority++;
            }
        }
    }
}
