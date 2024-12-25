using UnityEngine;

public class ScriptShooting : BaseSpawner<ScriptShooting>
{
    [SerializeField] private Transform bulletPrefab;
    private float _fireRate; // fire speed
    private float _lastTimeShot;

    protected override void Reset_LoadObjects()
    {
        bulletPrefab = BulletsList.Instance.prefab;
    }

    protected override void Awake_ResetValues()
    {
        var shipData = Resources.Load<ShipData>("MainShip");
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
        ScriptBulletPoolObject.Instance.Spawn(bulletPrefab, transform.parent.position,
            transform.parent.rotation);

        _lastTimeShot = Time.time;
    }
}