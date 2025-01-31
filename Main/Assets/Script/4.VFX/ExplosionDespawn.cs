using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDeath : BaseDespawn
{
    protected override List<Transform> GetPoolList() => VFXPoolObject.Instance.poolList;
    
    private float spawnTime;

    protected void OnEnable() => spawnTime = Time.time;

    protected override void Start() => OnEnable();

    protected override bool CanDespawn() => Time.time - spawnTime >= .3;
}
