using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemDespawn : BaseDespawn
{
    private float spawnTime;
    protected override List<Transform> GetPoolList() => DropItemPoolObject.Instance.poolList;

    protected void OnEnable() => spawnTime = Time.time;
    protected override void Start() => OnEnable();

    protected override bool CanDespawn() => Time.time - spawnTime >= 30;
}
