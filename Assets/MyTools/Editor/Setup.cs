using UnityEditor;
using UnityEngine;
using System.IO;
using static System.IO.Directory;
using static System.IO.Path;
using static UnityEditor.AssetDatabase;



public static class Setup {
    [MenuItem("Tools/Setup/Create Default Folders")]
    public static void CreateDefaultFolders()
    {
        Folders.CreateDefault("_Project", "Animation", "Art", "Materials", "Prefabs", "ScriptableObjects", "Scripts", "Settings");
        Refresh();
    }
    [MenuItem("Tools/Setup/Import My Favorite Assets")]
    public static void ImportMyFavoriteAssets() {
        Assets.ImportAsset("DOTweenHOTweenv2.unitypackage", "Demigiant/EditorExtensionsAnimation");
    }

    static class Folders {
        public static void CreateDefault(string root, params string[] folders)
        {
            string fullpath = Path.Combine(Application.dataPath, root);
            
            foreach (string folder in folders)
            {
                string path = Path.Combine(fullpath, folder);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    Debug.Log("Dossier créé : " + path);
                }
            }
        }
    }

    public static class Assets {
        public static void ImportAsset(string asset, string subfolder, string folder = "C:/Users/wmben/AppData/Roaming/Unity/Asset Store-5.x") {
            ImportPackage(Combine(folder, subfolder, asset), false);
        }
    }
}
