using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScriptBullet1Despawn : BaseDespawner
{
    public float spawnTime;

    protected void Start()
    {
        spawnTime = Time.time;
    }

    protected override bool CanDespawn() => Time.time - spawnTime >= 3;

    protected override void Despawn()
    {
        transform.parent.gameObject.SetActive(false);
        ScriptBullet1Spawn.Instance.poolList.Add(transform.parent);
    }
}