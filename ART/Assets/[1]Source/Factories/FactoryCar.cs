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
        [SerializeField]
        GameObject prefabOfSkate;

        public Transform SpawnCar(Vector3 pos, Quaternion rot, Transform parent, int TypeOfCar)
        {
            Transform transformCar = null ;
            
            switch (TypeOfCar)
            {
                case Tag.Car:
                    transformCar = this.Populate(Pool.None, prefabOfCar, pos, rot);
                    break;
                case Tag.SkateBoard:
                    transformCar = this.Populate(Pool.None, prefabOfSkate, pos, rot);
                    break;
                default:
                    break;
            }
            transformCar.parent = parent;
            return transformCar;
        }


    }
}
