using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseShooting : BaseSpawn
{
    [SerializeField] protected float _fireRate; // fire speed
    [SerializeField] protected float _lastTimeShot;

    protected override void Awake_ResetValues()
    {
        base.Awake_ResetValues();
        _fireRate = GetFireRate();
    }

    protected abstract float GetFireRate();
    
    protected override BasePoolPattern GetPoolPattern() => PoolObjectCenter.Instance.bullet;

    protected override bool CanSpawn() => Time.time - _lastTimeShot > _fireRate;
    protected override void Spawner()
    {
        if (!CanSpawn()) return;
        Spawn();
        _lastTimeShot = Time.time;
        //Debug.Log("s");
    }
}