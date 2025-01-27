using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScriptBullet1Despawn : BaseDespawn
{
    public float spawnTime;

    protected override void Awake_ResetValues()
    {
        poolList = BulletPoolObject.Instance.poolList;
    }

    protected void OnEnable() => spawnTime = Time.time;

    protected override void Start() => OnEnable();

    protected override bool CanDespawn() => Time.time - spawnTime >= 3;
}