using System.Collections.Generic;
using UnityEngine;

public class Bullet1Despawn : BaseDespawn
{
    protected override List<Transform> GetPoolList() => BulletPoolObject.Instance.poolList;

    private float spawnTime;

    protected void OnEnable() => spawnTime = Time.time;

    protected override void Start() => OnEnable();

    protected override bool CanDespawn() => Time.time - spawnTime >= 3;

    protected void OnDisable()
    {
        VFXPoolObject.Instance.Spawn(ListVFX.Instance.prefab, transform.parent.position,
            transform.parent.rotation);
    }
}