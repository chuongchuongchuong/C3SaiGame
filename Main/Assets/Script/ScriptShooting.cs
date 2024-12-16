using UnityEngine;

public class ScriptShooting : ChuongMono<ScriptShooting>
{
    private float _fireRate; // fire speed
    private float _lastTimeShot;
    
    protected override void GetScriptableDataValue()
    {
        var shipData = Resources.Load<ShipData>("MainShip");
        _fireRate = shipData.fireRate;
    }

    private void Update()
    {
        // if not pressin left click, nothing
        if (ScriptInputManager.Instance.onFiring != 1) return;
        // if pressin left click, but not enough the cooldown time, nothing
        if (Time.time - _lastTimeShot < _fireRate) return;
        
        ScriptBullet1Spawn.Instance.Spawn("Bullet_1", transform.parent.position, transform.parent.rotation);
        
        _lastTimeShot = Time.time;
    }
}