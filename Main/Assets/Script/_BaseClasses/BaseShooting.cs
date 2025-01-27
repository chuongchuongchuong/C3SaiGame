using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseShooting : BaseSpawn
{
    protected float _fireRate; // fire speed
    protected float _lastTimeShot;
    protected Transform bulletPrefab;

    protected override bool CanSpawn()
    {
        // if not pressin left click, nothing
        if (InputManager.Instance.onFiring != 1) return false;
        // if pressin left click, but not enough the cooldown time, nothing
        if (Time.time - _lastTimeShot < _fireRate) return false;

        return true;
    }

    protected override void Spawn()
    {
        bulletPrefab=GetBulletPrefab();
        BulletPoolObject.Instance.Spawn(bulletPrefab, transform.position, transform.parent.rotation);

        _lastTimeShot = Time.time;
    }

    protected abstract Transform GetBulletPrefab();
}