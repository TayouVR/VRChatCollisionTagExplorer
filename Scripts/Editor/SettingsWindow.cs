using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace com.tayouvr.vrchatcollisiontagexplorer
{
    public class SettingsWindow : EditorWindow
    {

        [MenuItem("Tools/VRChat Community Collision Tags")]
        static void Init()
        {
            // Get existing open window or if none, make a new one:
            SettingsWindow window = (SettingsWindow)EditorWindow.GetWindow(typeof(SettingsWindow));
            window.titleContent = new GUIContent("VRChat Community Collision Tags");
            window.Show();
        }

        void OnGUI()
        {
            GUIStyle centeredStyle = new GUIStyle(GUI.skin.label);
            centeredStyle.alignment = TextAnchor.UpperCenter;
            centeredStyle.fontSize = 30;

            //Header
            GUILayout.Label("VRChat Community Collision Tag Explorer", centeredStyle);

            if (string.IsNullOrEmpty(EditorPrefs.GetString("VCCTRepoUrl")))
            {
                EditorPrefs.SetString("VCCTRepoUrl", "https://raw.githubusercontent.com/TayouVR/VRChatCollisionTagDatabase/main/registry.json");
            }
            EditorPrefs.SetString("VCCTRepoUrl", EditorGUILayout.TextField("Repository URL", EditorPrefs.GetString("VCCTRepoUrl")));

            if (GUILayout.Button("(Re)Load Registry")) {
                CommonFunctions.DownloadRegistry();
            }

            if (!System.IO.File.Exists(string.Format("{0}/{1}.json", Application.persistentDataPath, "registry"))) return;

            JObject jobject = JObject.Parse(System.IO.File.ReadAllText(string.Format("{0}/{1}.json", Application.persistentDataPath, "registry")));

            EditorGUILayout.LabelField("Registry Name: " + (string)jobject["registryName"]);
            JArray libraryDescriptors = (JArray)jobject["libraries"];

            //EditorGUILayout.TextArea(jobject.Property("libraries").Value.ToString());

            if (GUILayout.Button("(Re)Load libraries"))
            {
                CommonFunctions.DownloadLibraries(jobject.Property("registryName").Value.ToString(), libraryDescriptors);
            }
            
            GUI.enabled = false;
            foreach (JObject library in CommonFunctions.GetDownlaodedLibraries())
            {
                EditorGUILayout.TextField("Name:", (string)library["name"]);
                EditorGUILayout.TextField("Description:", (string)library["description"]);
                EditorGUI.indentLevel++;
                foreach (var entry in (JArray)library["entries"])
                {
                    EditorGUILayout.TextField("Tag:", (string)entry["tag"]);
                    EditorGUILayout.TextField("Description:", (string)entry["description"]);
                    EditorGUILayout.LabelField("Alteratives:");
                    EditorGUI.indentLevel++;
                    foreach (var alternative in (JArray)entry["alternatives"])
                    {
                        EditorGUILayout.TextField((string)alternative);
                    }
                    EditorGUI.indentLevel--;
                }
                EditorGUI.indentLevel--;
            }
            GUI.enabled = true;
        }
    }
}