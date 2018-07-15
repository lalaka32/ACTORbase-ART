using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Homebrew;

namespace BeeFly
{
    [CreateAssetMenu(fileName = "FactorySign", menuName = "Factories/FactorySign")]
    class FactorySign: Factory
    {
        [SerializeField]
        GameObject prefabOFSignMain;

        [SerializeField]
        GameObject prefabOFSignSecondary;

        public List<Transform> TrafficSignsMain { get; private set; } = new List<Transform>();

        public List<Transform> TrafficSignsSecondary { get; private set; } = new List<Transform>();

        public Transform SpawnSignMain(Vector3 pos, Quaternion rot,Transform parent)
        {
            var transform = this.Populate(Pool.None, prefabOFSignMain, pos, rot);
            //transform.eulerAngles = new Vector3(-90, 0, 0);
            transform.parent = parent;
            TrafficSignsMain.Add(transform);
            return transform;
        }
        public Transform SpawnSignSecondary(Vector3 pos, Quaternion rot, Transform parent)
        {
            var transform = this.Populate(Pool.None, prefabOFSignSecondary, pos, rot);
            //transform.eulerAngles = new Vector3(-90, 0, 0);
            transform.parent = parent;
            TrafficSignsSecondary.Add(transform);
            return transform;
        }
    }
}
