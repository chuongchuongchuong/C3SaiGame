using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseSpawner<T> : ChuongMono<T> where T : BaseSpawner<T>
{
    [SerializeField] private List<Transform> bulletList;
    [SerializeField] public List<Transform> poolList;
    [SerializeField] protected Transform spawnHolder;

    protected override void LoadObjects()
    {
        foreach (Transform child in transform)
        {
            bulletList.Add(child);
        }
    }


    public virtual void Spawn(string prefabName, Vector3 shipPosition, Quaternion shipRotation)
    {
        var objectTaken = GetObjectFromPool(prefabName);
        // nếu lấy được prefab trong pool, thì sẽ bật Active lại viên đạn dó
        if (objectTaken != null) RespawnFromPool();
        else SpawnNewPrefab(); // nếu ko lấy được thì tạo prefab mới
        return;

        //Hàm lấy 1 prefab từ trong Pool
        Transform GetObjectFromPool(string prefabName = null)
        {
            foreach (var obj in poolList)
            {
                if (obj.name == prefabName) return obj;
            }

            return null;
        }

        void RespawnFromPool()
        {
            objectTaken.gameObject.SetActive(true);
            objectTaken.position = shipPosition; // reset the position for the bullet
            objectTaken.rotation = shipRotation; // reset the rotation for the bullet
            objectTaken.GetComponentInChildren<ScriptBullet1Despawn>().spawnTime = Time.time;
            poolList.Remove(objectTaken);
            Debug.Log("run here");
        }

        void SpawnNewPrefab()
        {
            var newBullet = Instantiate(GetPrefabByName(prefabName), shipPosition, shipRotation, spawnHolder);
            newBullet.gameObject.name = prefabName;
            newBullet.gameObject.SetActive(true);
            return;

            //Chọn loại đạn nào sẽ được spawn ra bằng tên
            Transform GetPrefabByName(string prefabName)
            {
                foreach (var prefab in bulletList)
                {
                    if (prefab.name == prefabName) return prefab;
                }

                return null;
            }
        }
    }
}