using UnityEngine;

public class PlayerShooting : BaseShooting
{
    #region Get Object Center
    [SerializeField] private PlayerCenter playerCenter;
    protected override void Reset_LoadObjectCenter() => playerCenter = transform.parent.GetComponent<PlayerCenter>();
    #endregion
    
    protected override void Awake_ResetValues()
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

    protected override Transform GetBulletPrefab() => playerCenter.bulletsList.prefab;
}