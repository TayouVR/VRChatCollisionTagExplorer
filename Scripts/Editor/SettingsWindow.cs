using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace AnimatorManager.Scripts.Editor
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

        private void OnEnable()
        {

        }

        void OnGUI()
        {
            GUIStyle centeredStyle = new GUIStyle(GUI.skin.label);
            centeredStyle.alignment = TextAnchor.UpperCenter;
            centeredStyle.fontSize = 30;

            //Header
            GUILayout.Label("Animator Manager", centeredStyle);

            EditorPrefs.SetString("VCCTRepoUrl", GUILayout.TextField("Repository URL", EditorPrefs.GetString("VCCTRepoUrl")));
        }
    }
}