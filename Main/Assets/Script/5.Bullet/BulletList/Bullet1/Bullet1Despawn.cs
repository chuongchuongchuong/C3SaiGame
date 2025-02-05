using System.Collections.Generic;
using UnityEngine;

public class Bullet1Despawn : BaseDespawn
{
    public override List<Transform> GetPoolList() => PoolObjectCenter.Instance.bullet.poolList;

    private float spawnTime;

    protected void OnEnable() => spawnTime = Time.time;

    protected override void Start() => OnEnable();

    protected override bool CanDespawn() => Time.time - spawnTime >= 3;

    /*protected void OnDisable()
    {
        var explosion = VFXPoolObject.Instance.Spawn(transform.parent.position,
            transform.parent.rotation);

        var despawn = explosion.GetComponent<ExplosionCenter>().Despawn;
        despawn.Invoke(nameof(Despawn), 1f);
    }*/
}