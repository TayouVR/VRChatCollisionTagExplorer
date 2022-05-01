using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEditor;
using System.IO;
using Newtonsoft.Json.Linq;

namespace com.tayouvr.vrchatcollisiontagexplorer
{
    public class CommonFunctions
    {
        public string cachedFile;

        public static void DownloadRegistry()
        {
            string savePath = string.Format("{0}/{1}.json", Application.persistentDataPath, "registry");
            DownloadFile(EditorPrefs.GetString("VCCTRepoUrl"), savePath);
        }

        public static void DownloadLibraries(string registryName, JArray libraries)
        {
            if (!Directory.Exists(string.Format("{0}/VRC_CollisionTagLibraries/", Application.persistentDataPath)))
                Directory.CreateDirectory(string.Format("{0}/VRC_CollisionTagLibraries/", Application.persistentDataPath));
            foreach (var library in libraries)
            {
                string savePath = string.Format("{0}/VRC_CollisionTagLibraries/{1}_{2}.json", Application.persistentDataPath, registryName, System.IO.Path.GetFileNameWithoutExtension((string)library["url"]));
                DownloadFile((string)library["url"], savePath);
            }
        }

        public static List<JObject> GetDownlaodedLibraries()
        {
            List<JObject> libraries = new List<JObject>();
            string[] files = Directory.GetFiles(string.Format("{0}/VRC_CollisionTagLibraries/", Application.persistentDataPath));
            foreach (string file in files)
                if (file.EndsWith(".json"))
                {
                    libraries.Add(JObject.Parse(File.ReadAllText(file)));
                }
            return libraries;
        }

        private static void DownloadFile(string url, string downloadPath)
        {
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            var thing = client.GetAsync(url);
            thing.Wait();
            var thing2 = thing.Result.Content.ReadAsStringAsync();
            thing2.Wait();
            System.IO.File.WriteAllText(downloadPath, thing2.Result);
        }
    }
}
