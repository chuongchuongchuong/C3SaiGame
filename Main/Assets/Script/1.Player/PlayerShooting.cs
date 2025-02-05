using UnityEngine;

public class PlayerShooting : BaseShooting
{
    #region Get Bullet Center

    [SerializeField] private BulletCenter bullet;
    protected override void LoadObjectCenter() => bullet ??= BulletCenter.Instance;

    #endregion

    protected override float GetFireRate()
    {
        var shipData = Resources.Load<ShipData>(StringKeeper.MainShipDataPath);
        return shipData.fireRate;
    }

    protected override Transform GetPrefab() => bullet.List.List[0];
    protected override Vector3 GetSpawnPosition() => transform.position;
    protected override Quaternion GetSpawnRotation() => transform.parent.rotation;
    
    protected override bool CanSpawn()
    {
        // if not pressin left click, nothing
        if (InputManager.Instance.onFiring != 1) return false;
        
        // if pressin left click, but not enough the cooldown time, nothing
        if (Time.time - _lastTimeShot < _fireRate) return false;

        return true;
    }
}