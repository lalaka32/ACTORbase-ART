using Homebrew;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FastDeb
{
    //Пока сыровато не советую юзать
    static class FastDebug
    {
        //tested
        static string StringTypeAndValue<T>(this T value)
        {
            return typeof(T).Name.ToString() + " : " + value;
        }
        //tested
        static string StringIsNull<T>(this T value)
        {
            return typeof(T).Name.ToString() + " is null";
        }
        //tested
        static string StringIsNotNull<T>(this T value)
        {
            return typeof(T).Name.ToString() + " is not null";
        }
        //tested
        static public bool ValidOnNullBool<T>(this T value, Action actionTrue = null, Action actionFalse = null)
        {
            if (value == null)
            {
                actionFalse?.Invoke();
                return false;
            }
            else
            {
                actionTrue?.Invoke();
                return true;
            }
        }
        //tested
        static string ValidOnNullString<T>(this T value, Action actionTrue = null, Action actionFalse = null)
        {
            if (value == null)
            {
                actionFalse?.Invoke();
                return value.StringIsNull();
            }
            else
            {
                actionTrue?.Invoke();
                return value.StringTypeAndValue();
            }
        }
        //tested
        static public T ValidOnNull<T>(this T value, Action actionTrue = null, Action actionFalse = null)
        {
            value.ValidOnNullBool(actionTrue, actionFalse);
            return value;
        }
        //tested
        static public T Print<T>(this T value)
        {
            return value.ValidOnNull(() => Debug.Log(value.StringTypeAndValue()), () => Debug.Log(value.StringIsNull()));
        }
        //tested
        static public bool PrintBoolIsNull<T>(this T value)
        {
            return value.ValidOnNullBool(() => Print(value.StringIsNotNull()), () => Print(value.StringIsNull()));
        }
        //tested
        static public KeyValuePair<K, V> PrintPair<K, V>(this KeyValuePair<K, V> pair)
        {
            pair.ValidOnNullBool(() =>
            {
                Debug.Log(pair.Key.ValidOnNullString() + " { | } " + pair.Value.ValidOnNullString());
            }, ()=> pair.StringIsNull());
            return pair;
        }
        //tested
        static public V PrintArray<V>(this V array) where V : IEnumerable
        {
            if (array.ValidOnNullBool())
            {
                foreach (var item in array)
                {
                    item.Print();
                }
            }
            return array;
        }
        //tested
        static public Dictionary<K, V> PrintDictionary<K, V>(this Dictionary<K, V> dictionary)
        {
            if (dictionary.ValidOnNullBool())
            {
                foreach (var item in dictionary)
                {
                    item.PrintPair();

                }
            }
            return dictionary;
        }

        /// <summary>
        /// !Require special behaviour!
        /// </summary>
        static public Actor PrintActor(this Actor actor)
        {
            return actor.ValidOnNull(() => actor.signals.Send(new SignalKillCar()), () => actor.StringIsNull());
        }

    }

}
