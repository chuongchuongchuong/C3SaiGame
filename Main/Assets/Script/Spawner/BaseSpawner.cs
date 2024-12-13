using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> prefabs;
    [SerializeField] protected Transform spawnPlace;

    protected virtual void Reset()
    {
        LoadPrefabs();
    }

    protected void LoadPrefabs()
    {
        foreach (Transform child in transform)
        {
            prefabs.Add(child);
        }
    }

    public virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (var prefab in prefabs)
        {
            if (prefab.name == prefabName) return prefab;
        }

        return null;
    }

    public virtual Transform Spawn(string preFabName, Vector3 spawnPos, Quaternion spawnRot)
    {
        var prefab = GetPrefabByName(preFabName);
        if (prefab == null)
        {
            Debug.LogWarning("prefab not found" + prefab.name);
            return null;
        }

        return Instantiate(prefab, spawnPos, spawnRot, spawnPlace);
    }
}