using UnityEngine;

public class ScriptShooting : MonoBehaviour
{
    private float _fireRate; // fire speed
    private float _lastTimeShot;
    


    private void Reset()
    {
    }

    private void Awake()
    {
        var shipData = Resources.Load<ShipData>("MainShip");
        _fireRate = shipData.fireRate;

        //bulletPrefab = ScriptBulletSpawner.Instance.bulletType;
    }

    private void Update()
    {
        // if not pressin left click, nothing
        if (ScriptInputManager.Instance.onFiring != 1) return;
        // if pressin left click, but not enough the cooldown time, nothing
        if (Time.time - _lastTimeShot < _fireRate) return;
        
        var bullet=ScriptBulletSpawner.Instance.Spawn("iblast_03", transform.parent.position, transform.parent.rotation);
        bullet.gameObject.SetActive(true);
        Destroy(bullet.gameObject, 3);
        
        _lastTimeShot = Time.time;
    }
}