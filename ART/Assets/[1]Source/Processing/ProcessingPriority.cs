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
            foreach (var situation in Toolbox.Get<DataArtSession>().CrossSituation)
            {
                RulesForCross rulesForExistingCross = ChooseRules(arg.typeOfCross);
                if (situation.car)
                {
                    Debug.Log(situation.actorCar.dataDirection.direction);
                    foreach (var rule in rulesForExistingCross.SelectRules(situation.actorCar.dataDirection.direction))
                    {
                        bool valid = ValidationRule(situation, rule);
                        IncrementPrioriry(situation.actorCar, valid);

                    }
                    Debug.Log("Pri:" + situation.actorCar.daraPriority.priority + " POs: " + situation.position);
                }
            }

        }

        private RulesForCross ChooseRules(int arg)
        {
            switch (arg)
            {
                case TypeOfCross.Qvalent:
                    return RulesForQvalent;
                case TypeOfCross.UnQvalent:
                    return RulesForUnQvalent;
                case TypeOfCross.Regularity:
                    return RulesForRegularity;
                default:
                    return null;
            }
        }

        bool ValidationRule(Situation settingSituation, FactoryRules rule)
        {
            bool validation = ValidationSelfCondition(rule.selfCondition, settingSituation);
            var settingComperative = settingSituation.actorCar.Get<DataComperativeCars>().comperative;
            foreach (var item in settingComperative)
            {
                // Debug.Log(item.Key+"<><><><>"+item.Value);
            }
            if (validation)
            {
                foreach (Condition condition in rule.conditions)
                {
                    Situation observeSituation;

                    settingComperative.TryGetValue(condition.comperativePosition, out observeSituation);
                    if (observeSituation == null)
                    {
                        validation = ValidateNullCondition(condition);
                    }
                    else
                    {
                        validation = ValidationCondition(condition, observeSituation);
                    }
                    //Debug.Log(validation);
                    if (!validation)
                        break;

                }
            }
            //Debug.Log(validation + "|\\\\|" );
            // Debug.Log("---------------------------------------");
            return validation;
        }
        bool ValidateNullCondition(Condition condition)
        {
            if (condition.car)
            {
                return false;
            }
            if (condition.hisTrafficLight!=TrafficLight.Empty)
            {
                return false;
            }
            if (condition.hisTrafficSign!=TrafficSign.Empty)
            {
                return false;
            }

            return true;
        }
        bool ValidationCondition(Condition condition, Situation observeSituation)
        {
            if (condition.car)
            {
                if (observeSituation.car)
                {
                    if (!ValidateType(Direction.None, condition.hisDirection, observeSituation.direction.direction))
                    {
                        return false;
                    }
                }
                else
                {

                    return false;
                }
            }
            else
            {
                if (observeSituation.car)
                {
                    return false;
                }
            }
            if (!ValidateTypeMiss(TrafficSign.Empty, condition.hisTrafficSign, observeSituation.trafficSign))
            {
                return false;
            }
            if (!ValidateTypeMiss(TrafficLight.Empty, condition.hisTrafficLight, observeSituation.trafficLight))
            {
                return false;
            }
            return true;
        }

        bool ValidationSelfCondition(SelfCondition condition, Situation observeSituation)
        {
            if (!ValidateType(Direction.None, condition.selfDirection, observeSituation.direction.direction))
            {
                return false;
            }
            if (!ValidateTypeMiss(TrafficLight.Empty, condition.selfTrafficLight, observeSituation.trafficLight))
            {
                return false;
            }
            if (!ValidateTypeMiss(TrafficSign.Empty, condition.selfTrafficSign, observeSituation.trafficSign))
            {
                return false;
            }
            return true;
        }

        bool ValidateTypeMiss<T>(T defaultValue, T condition, T situation) where T : struct
        {
            if (!condition.Equals(defaultValue))
            {
                if (!condition.Equals(situation))
                {
                    return false;
                }
            }
            else
            {
                if (!situation.Equals(defaultValue))
                {
                    return false;
                }
            }
            return true;
        }

        bool ValidateType<T>(T defaultValue, T condition, T situation) where T : struct
        {
            if (!condition.Equals(defaultValue))
            {
                if (!condition.Equals(situation))
                {
                    return false;
                }
            }
            return true;
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