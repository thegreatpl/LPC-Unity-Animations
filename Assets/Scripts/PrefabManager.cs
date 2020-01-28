using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public List<Prefab> Prefabs; 



    public GameObject GetPrefab(string name)
    {
        return Prefabs.FirstOrDefault(x => x.Name == name)?.GameObject; 
    }
}
