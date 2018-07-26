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

        public RulesForCross RulesForQvalent;

        public RulesForCross RulesForUnQvalent;

        public RulesForCross RulesForRegularity;

        public void HandleSignal(SignalSetPriority arg)
        {
            foreach (var car in cars.actors)
            {
                //car.signals.Send(new SignalSetPriority());

                foreach (var rule in RulesForQvalent.SelectRules(car.Get<DataDirection>().direction))
                {
                    bool valid = ValidationRule(car, rule);
                    IncrementPrioriry(car, valid);
                    //Debug.Log(valid + rule.name);
                }
                Debug.Log("Pri:" + car.Get<DataPriority>().priority + " POs: " + car.name);
            }

        }
        bool ValidationRule(Actor settingCar, FactoryRules rule)
        {
            bool validation = false;
            var settingComperative = settingCar.Get<DataComperativeCars>().comperative;

            #endregion

            foreach (Condition condition in rule.conditions)
            {
                validation = ValidationCondition(condition, settingComperative);
                if (!validation)
                    break;
            }
            return validation;

            #region Down
        }

        bool ValidationCondition(Condition condition, Dictionary<int, Actor> settingComperative)
        {

            Actor observeCar;
            bool validation;
            settingComperative.TryGetValue(condition.comperativePosition, out observeCar);
            if (condition.car)
            {
                if (observeCar != null)
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
                        }
                    }
                }
                else
                {
                    validation = false;
                }
            }
            else
            {
                if (observeCar == null)
                {
                    validation = true;
                }
                else
                {
                    validation = false;
                }
            }
            return validation;
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