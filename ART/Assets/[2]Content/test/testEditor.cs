using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(test))]
[CanEditMultipleObjects]
public class testEditor : Editor
{
    SerializedProperty KickAss;

    private void OnEnable()
    {
        KickAss = serializedObject.FindProperty("KickAss");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(KickAss);
        serializedObject.ApplyModifiedProperties();
        if (KickAss.intValue > 10)
        {
            EditorGUILayout.LabelField("/(0_0)/");
        }
        else if (KickAss.intValue < -10)
        {
            EditorGUILayout.LabelField("\\(0_0)\\");
        }
        else
        {
            EditorGUILayout.LabelField("\\(0_0)/");
        }
    }
}
