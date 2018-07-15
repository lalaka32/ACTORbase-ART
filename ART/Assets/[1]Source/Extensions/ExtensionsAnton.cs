using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BeeFly
{
    static class ExtensionsAnton
    {
        private static System.Random _r = new System.Random();

        public static List<T> Shaffle<T>(this List<T> listToShaffle)
        {
            for (int i = listToShaffle.Count - 1; i >= 1; i--)
            {
                int j = UnityEngine.Random.Range(0, i);
                var temp = listToShaffle[j];
                listToShaffle[j] = listToShaffle[i];
                listToShaffle[i] = temp;
            }
            return listToShaffle;

        }
        public static V Random<K, V>(this Dictionary<K, V> dictionary)
        {
            V value = dictionary.ElementAt(_r.Next(0, dictionary.Count)).Value;
            return value ;
        }
    }
}
