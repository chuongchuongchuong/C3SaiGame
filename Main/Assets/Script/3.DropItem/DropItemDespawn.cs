using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemDespawn : BaseDespawn
{
    private float spawnTime;
    protected override void ResetValues_Awake()
    {
        poolList = DropItemPoolObject.Instance.poolList;
    }

    protected override void OnEnable() => spawnTime = Time.time;

    protected override bool CanDespawn() => Time.time - spawnTime >= 30;
}
