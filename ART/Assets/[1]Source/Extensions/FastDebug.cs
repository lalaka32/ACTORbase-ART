using Homebrew;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FastDeb
{
    static class FastDebug
    {
        //tested
        static public void DebugMark()
        {
            Debug.Log("Success");
        }
        //tested
        static string StringTypeAndValueOut<T>(this T value)
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
                return value.StringTypeAndValueOut();
            }
        }
        //tested
        static public T ValidOnNull<T>(this T value, Action actionTrue = null, Action actionFalse = null)
        {
            value.ValidOnNullBool(actionTrue, actionFalse);
            return value;
        }
        //tested
        static public T DebugOutToString<T>(this T value)
        {
            return value.ValidOnNull(() => Debug.Log(value.StringTypeAndValueOut()));
        }
        //tested
        static public bool DebugValidOnNullOut<T>(this T value)
        {
            return value.ValidOnNullBool(() => Debug.Log(value.StringIsNotNull()), () => Debug.Log(value.StringIsNull()));
        }
        //tested
        static public KeyValuePair<K, V> DebugPairOut<K, V>(this KeyValuePair<K, V> pair)
        {
            pair.ValidOnNullBool(() =>
            {
                Debug.Log(pair.Key.ValidOnNullString() + " { | } " + pair.Value.ValidOnNullString());
            });
            return pair;
        }
        //tested
        static public V DebugArrayOut<V>(this V array) where V : IEnumerable
        {
            if (array.ValidOnNullBool())
            {
                foreach (var item in array)
                {
                    item.DebugOutToString();
                }
            }
            return array;
        }
        //tested
        static public Dictionary<K, V> DebugDictionaryOut<K, V>(this Dictionary<K, V> dictionary)
        {
            if (dictionary.ValidOnNullBool())
            {
                foreach (var item in dictionary)
                {
                    item.DebugPairOut();
                }
            }
            return dictionary;
        }

        /// <summary>
        /// !Require special behaviour!
        /// </summary>
        static public Actor DebugActorOut(this Actor actor)
        {
            return actor.ValidOnNull(() => actor.signals.Send(new SignalDebugOut()));
        }
    }
}
