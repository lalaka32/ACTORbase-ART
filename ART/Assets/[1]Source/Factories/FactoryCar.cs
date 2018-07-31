using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Homebrew;

namespace BeeFly
{
    [CreateAssetMenu(fileName = "FactoryCar", menuName = "Factories/FactoryCar")]
    class FactoryCar : Homebrew.Factory
    {
        [SerializeField]
        GameObject prefabOfCar;


        public Transform SpawnCar(Vector3 pos, Quaternion rot, Transform parent)
        {
            var transformCar = this.Populate(Pool.None, prefabOfCar, pos, rot);
            transformCar.parent = parent;
            //бля не ебу поч тут нада делать таймер
            return transformCar;
        }


    }
}
