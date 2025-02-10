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

    public List<Transform> SpawnPoints = new();
    private Transform spawnPoint;

    protected override void Reset_LoadObjects()
    {
        foreach (Transform child in transform)
        {
            SpawnPoints.Add(child);
        }
    }
    
    protected override BasePoolPattern GetPoolPattern() => PoolObjectCenter.Instance.enemy;
    protected override Transform GetPrefab() => EnemyList.Instance.List[0];

    protected override Vector3 GetSpawnPosition()
    {
        spawnPoint = SpawnPoints[Random.Range(0, 2)];
        return spawnPoint.position;
    }

    protected override Quaternion GetSpawnRotation()
    {
        if (spawnPoint == SpawnPoints[0]) return Quaternion.Euler(0, 0, 180);
        else return Quaternion.Euler(0, 0, 0);
    }

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
        spawnedMinion.GetComponent<Enemy_1Center>().modelOnAppear.AppearScale();
    }
}