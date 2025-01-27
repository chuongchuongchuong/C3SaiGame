using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDeath : ChuongMono
{
    [SerializeField] private BaseHealth health;
    [SerializeField] private JunkDespawn despawner;

    protected override void Reset_LoadComponents()
    {
        health = transform.parent.GetComponentInChildren<BaseHealth>();
        despawner = GetComponent<JunkDespawn>();
    }

    protected virtual void Update()
    {
        if (!health.IsDead()) return;
        despawner.Despawn(); //Get back to pool object
    }

    protected virtual void OnDisable() => OnDeathDrop();

    protected virtual void OnDeathDrop()
    {
        var dropPrefab = DropList.Instance.DropItem();
        if (dropPrefab == null) return;
        DropItemPoolObject.Instance.Spawn(dropPrefab.transform,
            transform.position, Quaternion.identity);
    }
}