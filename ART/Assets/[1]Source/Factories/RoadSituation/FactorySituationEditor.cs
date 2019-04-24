//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Homebrew;
//using UnityEditor;
//using UnityEngine;

//namespace BeeFly
//{
//    [CustomEditor(typeof(FactorySituation))]
//    class FactorySituationEditor : Editor
//    {
//        FactorySituation factorySituation;
//        private void OnEnable()
//        {
//            factorySituation = target as FactorySituation;
//        }
//        public override void OnInspectorGUI()
//        {
            
//            for (int iCase = 0; iCase < factorySituation.Cases.Count; iCase++)
//            {
//                if (factorySituation.Cases[iCase].car)
//                {
//                    if (factorySituation.Cases[iCase].player)
//                    {
//                        EditorGUILayout.LabelField("Player is " + iCase + "-th car");
//                    }
//                }
//            }
            
//            GUILayout.Space(5);
//            base.OnInspectorGUI();
//        }

//    }
//}
