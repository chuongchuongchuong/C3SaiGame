using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseSpawn : ChuongMono
{
    protected virtual void Update() => Spawner();

    protected virtual void Spawner()
    {
        if (!CanSpawn()) return;
        Spawn();
    }

    protected virtual bool CanSpawn() => false;

    public virtual Transform Spawn() => GetPoolPattern().Spawn(GetPrefab(), GetSpawnPosition(), GetSpawnRotation());

    protected abstract BasePoolPattern GetPoolPattern();

    protected abstract Transform GetPrefab();

    protected abstract Vector3 GetSpawnPosition();

    protected abstract Quaternion GetSpawnRotation();
}