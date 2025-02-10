using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : BaseDespawn
{
    
    #region Get Object Center

    [SerializeField] private Enemy_1Center enemy1Center;
    protected override void LoadObjectCenter() => enemy1Center = transform.parent.GetComponent<Enemy_1Center>();

    #endregion
    public override List<Transform> GetPoolList() => PoolObjectCenter.Instance.enemy.poolList;
    
    protected override bool CanDespawn() => enemy1Center.health.IsDead();
}