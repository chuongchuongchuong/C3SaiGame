using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonMinions : BaseSpawn
{
    // @formatter:off
    [Header("Summon Minions")]
    [SerializeField] protected float lastTimeUse;
    [SerializeField] protected float cooldownTime;
    // @formatter:on
    protected override BasePoolPattern GetPoolPattern() => PoolObjectCenter.Instance.enemy;

    protected override Transform GetPrefab() => EnemyList.Instance.List[0];

    protected override Vector3 GetSpawnPosition() => transform.parent.position;
    protected override Quaternion GetSpawnRotation() => transform.parent.rotation;

    protected override bool CanSpawn() => Time.time - lastTimeUse > cooldownTime;

    public override Transform Spawn()
    {
        lastTimeUse = Time.time;
        return base.Spawn();
    }

    protected override void Spawner()
    {
        if (!CanSpawn()) return;
        var spawnedMinion = Spawn();
        
        lastTimeUse = Time.time;
        spawnedMinion.GetComponent<Enemy_1Center>().model.AppearScale();
    }
}