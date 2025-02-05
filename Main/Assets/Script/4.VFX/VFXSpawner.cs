using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXSpawner : BaseSpawn
{
    protected override BasePoolPattern GetPoolPattern() => PoolObjectCenter.Instance.vfx;

    protected override Transform GetPrefab() => ListVFX.Instance.List[0];
    protected override Vector3 GetSpawnPosition() => new();
    protected override Quaternion GetSpawnRotation() => new();
}
