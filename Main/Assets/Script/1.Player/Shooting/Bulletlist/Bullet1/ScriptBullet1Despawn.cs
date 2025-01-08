using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScriptBullet1Despawn : BaseDespawner
{
    public float spawnTime;

    protected override void ResetValues_Awake()
    {
        poolList = ScriptBulletPoolObject.Instance.poolList;
    }

    protected override void OnEnable() => spawnTime = Time.time;

    protected override bool CanDespawn() => Time.time - spawnTime >= 3;
}