using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Homebrew;

namespace BeeFly
{
    [CreateAssetMenu(fileName = "FactoryCross", menuName = "Factories/FactoryCross")]
    class FactoryCross : Factory
    {
        [SerializeField]
        GameObject prefabOfCross;

        [SerializeField]
        GameObject prefabOfTrafficLight;

        [SerializeField]
        GameObject prefabOFSignMain;

        [SerializeField]
        GameObject prefabOFSignSecondary;

        public Transform Cross { get;private set; }

        public List<Transform> TrafficLights { get; private set; }

        public List<Transform> TrafficSignsMain { get; private set; }

        public List<Transform> TrafficSignsSecondary { get; private set; }

        /// <summary>
        /// Please use it first
        /// </summary>
        public Transform Spawn(Vector3 pos, Quaternion rot,WorldParenters perent)
        {
            Cross = this.Populate(Pool.Entities, prefabOfCross, pos,rot,null,perent);
            Cross.name = "Cross";
            return Cross;
            #region AR
            //if (AR)
            //{
            //    Cross.GetComponent<ImageTargetBehaviour>().enabled = true;
            //    Cross.GetComponent<DefaultInitializationErrorHandler>().enabled = true;
            //    Cross.GetComponent<TurnOffBehaviour>().enabled = true;
            //    Cross.GetComponent<DefaultTrackableEventHandler>().enabled = true;
            //}
            //Cross.transform.eulerAngles = new Vector3(0, 0, 0);
            #endregion
        }
        //Пока очень не нравится этот код
        //Очень опасный, и не оcобо понятно как чистить
        public Transform SpawnTL(Vector3 pos, Quaternion rot)
        {
            var transform = this.Populate(Pool.Entities, prefabOfTrafficLight, pos, rot, Cross);
            //TrafficLights.Add(transform);
            return transform;
        }
        public Transform SpawnSignMain(Vector3 pos, Quaternion rot)
        {
            var transform = this.Populate(Pool.Entities, prefabOFSignMain, pos, rot, Cross);
            //TrafficSignsMain.Add(transform);
            return transform;
        }
        public Transform SpawnSignSecondary(Vector3 pos, Quaternion rot)
        {
            var transform = this.Populate(Pool.Entities, prefabOFSignSecondary, pos, rot, Cross);
            //TrafficSignsSecondary.Add(transform);
            return transform;
        }
    }
}
