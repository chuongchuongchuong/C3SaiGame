using UnityEngine;
using System.Collections.Generic;

public class BasePoolPattern<T> : ChuongMonoSingleton<T> where T : BasePoolPattern<T>
{
    public List<Transform> poolList = new();

    public virtual void Spawn(Vector3 position, Quaternion rotation)
    {
        var objectTaken = GetObjectFromPool();
        // nếu lấy được prefab trong pool, thì sẽ bật Active lại viên đạn dó
        if (objectTaken != null) RespawnFromPool(objectTaken,position, rotation);
        else SpawnNewPrefab(position, rotation); // nếu ko lấy được thì tạo prefab mới
    }

// @formatter:off
    protected virtual Transform GetObjectFromPool(){return null;} //Hàm lấy 1 prefab từ trong Pool
    protected virtual void RespawnFromPool(Transform objectTaken, Vector2 position, Quaternion rotation){} //Hàm SetActive lại cho object từ pool
    protected virtual void SpawnNewPrefab(Vector2 position, Quaternion rotation){}//Hàm sinh ra object mới
    // @formatter:on
}