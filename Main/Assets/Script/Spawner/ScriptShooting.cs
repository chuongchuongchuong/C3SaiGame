using UnityEngine;

public class ScriptShooting : BaseSpawner<ScriptShooting>
{
    private float _fireRate; // fire speed
    private float _lastTimeShot;

    protected override void ResetValues()
    {
        var shipData = Resources.Load<ShipData>("MainShip");
        _fireRate = shipData.fireRate;
    }

    protected override bool CanSpawn()
    {
        // if not pressin left click, nothing
        if (ScriptInputManager.Instance.onFiring != 1) return false;
        // if pressin left click, but not enough the cooldown time, nothing
        if (Time.time - _lastTimeShot < _fireRate) return false;

        return true;
    }

    protected override void Spawn()
    {
        ScriptBulletPoolObject.Instance.Spawn(transform.parent.position,
            transform.parent.rotation);

        _lastTimeShot = Time.time;
    }
}