/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRC.SDK3.Dynamics.Contact.Components;
using UnityEditor;


namespace com.tayouvr.vrchatcollisiontagexplorer
{
    [UnityEditor.CustomEditor(typeof(VRCContactReceiver))]
    public class VRCContactReceiverCommunityEditor : Editor
    {
        VRCContactReceiver targetObject;

        protected void Awake()
        {
            targetObject = (VRCContactReceiver)target;
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
}*/