using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDespawn : BaseDespawn
{
    public override List<Transform> GetPoolList() => PoolObjectCenter.Instance.vfx.poolList;
    
    private float spawnTime;

    protected void OnEnable() => spawnTime = Time.time;

    protected override void Start() => OnEnable();

    protected override bool CanDespawn() => Time.time - spawnTime >= .3;
}
