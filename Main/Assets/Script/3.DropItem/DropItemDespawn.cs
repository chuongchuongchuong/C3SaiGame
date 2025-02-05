using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemDespawn : BaseDespawn
{
    private float spawnTime;
    public bool IsLooted;
    public override List<Transform> GetPoolList() => PoolObjectCenter.Instance.dropItem.poolList;

    protected void OnEnable() => spawnTime = Time.time;
    protected override void Start() => OnEnable();

    protected override bool CanDespawn()
    {
        if (IsLooted) return true;
        if (Time.time - spawnTime >= 30) return true;

        return false;
    }

    public override void Despawn(Transform obj, List<Transform> poolList)
    {
        base.Despawn(obj, poolList);
        IsLooted = false;
    }
}