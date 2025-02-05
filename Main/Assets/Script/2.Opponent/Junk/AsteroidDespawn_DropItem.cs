using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDespawn_DropItem : BaseSpawn
{
    protected override BasePoolPattern GetPoolPattern() => PoolObjectCenter.Instance.dropItem;

    protected override Transform GetPrefab() => DropList.Instance.RandomDropItem();

    protected override Vector3 GetSpawnPosition() => transform.parent.position;

    protected override Quaternion GetSpawnRotation() => Quaternion.identity;
    
    protected virtual void OnDisable() => OnDeathDrop();

    protected virtual void OnDeathDrop() => this.Spawn();
}
