using UnityEngine;
using System.Collections.Generic;

public abstract class BasePoolPattern<T> : ChuongMonoSingleton<T> where T : BasePoolPattern<T>
{
    public List<Transform> poolList = new();

    public virtual void Spawn(Transform prefab, Vector3 position, Quaternion rotation)
    {
        var takenObject = GetObjectFromPool(prefab);
        // nếu lấy được prefab trong pool, thì sẽ bật Active lại viên đạn dó
        if (takenObject != null) RespawnFromPool(takenObject, position, rotation);
        else SpawnNewPrefab(prefab, position, rotation); // nếu ko lấy được thì tạo prefab mới
    }

    //Hàm lấy 1 prefab từ trong Pool
    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach (var obj in poolList)
        {
            if (obj.name == prefab.name + "(Clone)") return obj;
        }

        return null;
    }

    //Hàm SetActive lại cho object từ pool
    protected virtual void RespawnFromPool(Transform takenObject, Vector2 position, Quaternion rotation)
    {
        takenObject.gameObject.SetActive(true);
        takenObject.position = position; // reset the position for the bullet
        takenObject.rotation = rotation; // reset the rotation for the bullet
        poolList.Remove(takenObject);
    }

    //Hàm sinh ra prefab mới
    protected virtual void SpawnNewPrefab(Transform prefab, Vector2 position, Quaternion rotation)
    {
        var newSpawn =
            Instantiate(prefab, position, rotation, transform);
        newSpawn.gameObject.SetActive(true);
    }
}