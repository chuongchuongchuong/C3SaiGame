using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBulletPoolObject : BasePoolPattern<ScriptBulletPoolObject>
{
    protected override Transform GetObjectFromPool()
    {
        foreach (var obj in poolList)
        {
            if (obj.name == BulletsList.Instance.weaponPrefab.name + "(Clone)") return obj;
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
        var newBullet =
            MonoBehaviour.Instantiate(BulletsList.Instance.weaponPrefab, position, rotation, transform);
        newBullet.gameObject.SetActive(true);
    }
}