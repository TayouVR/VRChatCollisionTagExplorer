using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRC.SDK3.Dynamics.Contact.Components;
using UnityEditor;
using HarmonyLib;
using System;
using System.Linq;

namespace com.tayouvr.vrchatcollisiontagexplorer
{
    [InitializeOnLoad, ExecuteInEditMode]
    public class VRCContactEditorExpansion {
        static VRCContactEditorExpansion() => Initialize();
        private static void Initialize()
        {
            try
            {
                //Create a harmony instance
                var myHarmony = new Harmony("ReceiverPatches");
                // Find Contact Assembly
                var assembly = AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(x => x.GetName().Name == "VRC.SDK3.Dynamics.Contact.Editor");
                // Find the base type
                var baseEditor = assembly.GetType("VRC.SDK3.Dynamics.Contact.VRCContactBaseEditor");
                // Find OnInspectorGUI method
                var method = AccessTools.Method(baseEditor, "OnInspectorGUI");
                // Patch this into our postfix method
                myHarmony.Patch(method, postfix: new HarmonyMethod(AccessTools.Method(typeof(VRCContactEditorExpansion), nameof(VRCContactSenderEditorPostfix))));
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
            }
        }
        public static void VRCContactSenderEditorPostfix(ref object __instance)
        {
            if (!(__instance is Editor editor)) return;
            EditorGUILayout.Space();
            if (__instance.GetType().Name == "VRCContactSenderEditor")
            {
                // your code for contact sender
                EditorGUILayout.LabelField("Browse Community Collision Tags!");
                // Just one target 
                var target = editor.target as VRCContactSender;
                // Multiple targets (multi-editing)
                var targets = editor.targets as VRCContactSender[];

                if (GUILayout.Button("Open Tag Browser")) {
                    SettingsWindow window = (SettingsWindow)EditorWindow.GetWindow(typeof(SettingsWindow));
                    window.SetSelectedContactSenders(targets);
                }

            }
            else if (__instance.GetType().Name == "VRCContactReceiverEditor")
            {
                // your code for contact receiver
                EditorGUILayout.LabelField("Browse Community Collision Tags!");
                // Just one target 
                var target = editor.target as VRCContactReceiver;
                // Multiple targets (multi-editing)
                var targets = editor.targets as VRCContactReceiver[];

                if (GUILayout.Button("Open Tag Browser"))
                {
                    SettingsWindow window = (SettingsWindow)EditorWindow.GetWindow(typeof(SettingsWindow));
                    window.SetSelectedContactReceivers(targets);
                }
            }
        }
    }
}