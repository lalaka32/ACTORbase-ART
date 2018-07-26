#region Up
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

                foreach (var rule in RulesForQvalent)
                {
                    bool valid = Validation(car, rule);
                    IncrementPrioriry(car, valid);
                    Debug.Log(valid);
                }
                Debug.Log(car.Get<DataPriority>().priority + "POs" + car.name);
            }

        }
        bool Validation(Actor settingCar, FactoryRules rule)
        {
            bool validation = false;
            var settingComperative = settingCar.Get<DataComperativeCars>().comperative;

            #endregion






            foreach (Condition condition in rule.conditions)
            {
                if (condition.car)
                {
                    Actor observeCar;
                    if (settingComperative.TryGetValue(condition.comperativePosition, out observeCar))
                    {
                        if (condition.hisDirection == Direction.None)
                        {
                            validation = true;
                        }
                        else
                        {
                            if (observeCar.Get<DataDirection>().direction == condition.hisDirection)
                            {
                                validation = true;
                            }
                            else
                            {
                                validation = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        validation = false;
                        break;
                    }
                }
                else
                {
                    validation = true;
                }
            }
            return validation;



















            #region Down
        }
        void IncrementPrioriry(Actor settingCar, bool Validation = true)
        {
            if (Validation)
            {
                settingCar.Get<DataPriority>().priority++;
            }
        }
    }
}

#endregion