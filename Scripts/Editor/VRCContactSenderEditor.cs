using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRCSDK.

public class VRCContactSenderCommunityEditor : VRCContactSenderEditor
{
    SerializedProperty targetObject;

    protected override void OnEnable()
    {
        base.OnEnable();
        targetObject = (VRCContectSender)serializedObject;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.Space();

        serializedObject.Update();
        //EditorGUILayout.PropertyField(m_testObject);
        serializedObject.ApplyModifiedProperties();
    }
}
