/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRC.SDK3.Dynamics.Contact.Components;
using UnityEditor;

namespace com.tayouvr.vrchatcollisiontagexplorer
{
    [UnityEditor.CustomEditor(typeof(VRCContactSender))]
    public class VRCContactSenderCommunityEditor : Editor
    {
        VRCContactSender targetObject;

        protected void Awake()
        {
            targetObject = (VRCContactSender)target;
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