using System.Collections;
using System.Collections.Generic;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;

public class ScriptJunkPoolObject : BasePoolPattern<ScriptJunkPoolObject>
{
    protected override Transform GetObjectFromPool()
    {
        foreach (var obj in poolList)
        {
            if (obj.name == JunkList.Instance.junkPrefab.name + "(Clone)") return obj;
        }

        return null;
    }

    protected override void RespawnFromPool(Transform objectTaken, Vector2 position, Quaternion rotation)
    {
        objectTaken.gameObject.SetActive(true);
        objectTaken.position = position; // reset the position for the bullet
        objectTaken.rotation = rotation; // reset the rotation for the bullet
        poolList.Remove(objectTaken);
    }

    protected override void SpawnNewPrefab(Vector2 position, Quaternion rotation)
    {
        var newJunk =
            Instantiate(JunkList.Instance.junkPrefab, position, rotation, transform);
        newJunk.gameObject.SetActive(true);
    }
}