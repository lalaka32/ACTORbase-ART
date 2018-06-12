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

        public Transform Cross { get;private set; }

        public Transform Spawn(Vector3 pos, Quaternion rot)
        {
            Cross = this.Populate(Pool.Entities, prefabOfCross, pos,rot,ProcessingScene.Default.Get("[SCENE]"));
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
        
    }
}
