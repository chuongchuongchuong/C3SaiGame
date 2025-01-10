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
        OnDeath();
    }

    private void OnDeath()
    {
        //Drop Item
        /*DropItemPoolObject.Instance.Spawn(DropList.Instance.prefab,
            transform.position, Quaternion.identity);*/
        
        //Get back to pool object
        despawner.Despawn();
    }
}