using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1Despawn_SpawnVFX : BaseSpawn
{
    protected override BasePoolPattern GetPoolPattern() => PoolObjectCenter.Instance.vfx;

    protected override Transform GetPrefab() => ListVFX.Instance.List[0];

    protected override Vector3 GetSpawnPosition() => transform.parent.position;
    protected override Quaternion GetSpawnRotation() => transform.parent.rotation;

    private void OnDisable() => Spawn();
}