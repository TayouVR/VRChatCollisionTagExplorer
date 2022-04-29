using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCContactReceiverCommunityEditor : VRCContactReceiverEditor
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
