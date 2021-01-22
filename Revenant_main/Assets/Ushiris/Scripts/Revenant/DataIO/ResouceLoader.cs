using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class ResouceLoader
{
    public static List<GameObject> Prefabs { get; private set; }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void LoadPrefabs()
    {
        Addressables.LoadAssetsAsync<GameObject>("RevenantObj", OnLoadPrefab);
    }

    static void OnLoadPrefab(GameObject prefab)
    {
        Debug.Log(prefab.name);
        Prefabs.Add(prefab);
    }
}
