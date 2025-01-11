using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDeath : ChuongPrefabs
{
    [SerializeField] private BaseHealth health;
    [SerializeField] private ScriptJunkDespawn despawner;

    protected override void LoadComponents_ResetInPrefab()
    {
        health = transform.parent.GetComponentInChildren<BaseHealth>();
        despawner = GetComponent<ScriptJunkDespawn>();
    }

    private void Update()
    {
        if (!health.IsDead()) return;
        despawner.Despawn(); //Get back to pool object

        OnDeathDrop();
    }

    private void OnDeathDrop()
    {
        var dropPrefab = DropList.Instance.DropItem();
        if (dropPrefab == null) return;
        DropItemPoolObject.Instance.Spawn(dropPrefab.transform,
            transform.position, Quaternion.identity);
    }
}