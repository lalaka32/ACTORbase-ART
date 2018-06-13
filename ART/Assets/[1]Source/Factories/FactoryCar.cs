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
    class FactoryCar : Factory
    {
        [SerializeField]
        GameObject prefabOfCar;

        public List<Transform> Cars { get; private set; } = new List<Transform>();


        public Transform SpawnCar(Vector3 pos, Quaternion rot, Transform parent)
        {
            var transform = this.Populate(Pool.Entities, prefabOfCar, pos, rot);
            transform.parent = parent;
            Cars.Add(transform);
            return transform;
        }

    }
}
