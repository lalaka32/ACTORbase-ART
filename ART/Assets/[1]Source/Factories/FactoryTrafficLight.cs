using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    [CreateAssetMenu(fileName = "FactoryTrafficLight", menuName = "Factories/FactoryTrafficLight")]
    class FactoryTrafficLight : Factory
    {
        [SerializeField]
        GameObject prefabOfTrafficLight;

        public List<Transform> TrafficLights { get; private set; } = new List<Transform>();

        public Transform SpawnTL(Vector3 pos, Quaternion rot, Transform parent)
        {
            var transform = this.Populate(Pool.None, prefabOfTrafficLight, pos, rot);
            transform.parent = parent;
            TrafficLights.Add(transform);
            return transform;
        }
    }
}
