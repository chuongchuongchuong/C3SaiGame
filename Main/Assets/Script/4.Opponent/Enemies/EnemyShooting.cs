using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : BaseShooting
{
    #region Get PlayerCenter

    [SerializeField] private Enemy_1Center enemy1;
    protected override void Reset_LoadObjectCenter() => enemy1 = transform.parent.GetComponent<Enemy_1Center>();

    #endregion

    protected override void Awake_ResetValues()
    {
        _fireRate = 1;
    }
    protected override Transform GetBulletPrefab() => transform.GetChild(0);
    
    protected override bool CanSpawn()
    {
        //Nếu chưa đủ gần thì enemy sẽ ko bắn
        if(!enemy1.movement.IsMinDistance()) return false;
        
        //If not enough the cooldown time, do nothing
        if (Time.time - _lastTimeShot < _fireRate) return false;

        return true;
    }
}
