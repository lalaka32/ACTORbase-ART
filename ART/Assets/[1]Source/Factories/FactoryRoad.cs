using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Homebrew;

namespace BeeFly
{
    [CreateAssetMenu(fileName = "FactoryRoad", menuName = "Factories/FactoryRoad")]
    class FactoryRoad : Factory
    {
        [SerializeField]
        GameObject prefabOfCross;

        [SerializeField]
        GameObject prefabOfTrafficLight;

        [SerializeField]
        GameObject prefabOfSignMain;

        [SerializeField]
        GameObject prefabOfSignSecondary;

        public void Spawn(Vector3 pos, Quaternion rot, int entityID ,Transform parent = null)
        {
            Transform obj;
            switch (entityID)
            {
                case Tag.Cross :
                    obj = this.Populate(Pool.None, prefabOfCross, pos, rot, null, WorldParenters.None);
                    obj.name = "Cross";
                    obj.eulerAngles = new Vector3(-90, 0, 0);
                    break;
                case  Tag.TrafficLight :
                    obj = this.Populate(Pool.None, prefabOfTrafficLight, pos, rot);
                    obj.parent = parent;
                    break;
                case Tag.SignMain:
                    obj = this.Populate(Pool.None, prefabOfSignMain, pos, rot);
                    obj.parent = parent;
                    break;
                case Tag.SignSecondary:
                    obj = this.Populate(Pool.None, prefabOfSignSecondary, pos, rot);
                    obj.parent = parent;
                    break;
            }
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
