using UnityEngine;

public class ScriptShooting : BaseSpawn
{
    private float _fireRate; // fire speed
    private float _lastTimeShot;

    protected override void ResetValues_Awake()
    {
        var shipData = Resources.Load<ShipData>(StringKeeper.MainShipDataPath);
        _fireRate = shipData.fireRate;
    }

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
        ScriptBulletPoolObject.Instance.Spawn(BulletsList.Instance.prefab,
            transform.position, transform.parent.rotation);

        _lastTimeShot = Time.time;
    }
}