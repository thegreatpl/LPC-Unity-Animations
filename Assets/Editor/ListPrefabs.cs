using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class ListPrefabs : MonoBehaviour
{
    [MenuItem("thegreatpl/ListPrefabs")]
    static void ListPrefabsInGame()
    {
        var prefabManager = SceneAsset.FindObjectOfType<PrefabManager>(); 
        if (prefabManager == null)
        {
            Debug.LogError("Unable to find prefab manager");
            return; 
        }

        var location = "Assets/Prefabs";

        var path = $"{Directory.GetCurrentDirectory()}/{location}";
        var files = Directory.EnumerateFiles(path); 
        var assets = AssetDatabase.LoadAllAssetsAtPath(path);
        prefabManager.Prefabs = new  List<Prefab>(); 
        foreach(var file in files)
        {
            var filename = Path.GetFileName(file);
            var ass = AssetDatabase.LoadAssetAtPath<GameObject>($"{location}/{filename}"); 
           // var ass = (GameObject)asset;
            if (ass == null)
                continue;
            prefabManager.Prefabs.Add( new Prefab()
            {
                GameObject = ass,
                Name = ass.name
            });
        }
    }
}
