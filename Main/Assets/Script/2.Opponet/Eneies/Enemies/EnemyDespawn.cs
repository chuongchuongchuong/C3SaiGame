using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : BaseDespawn
{
    
    #region Get Object Center

    [SerializeField] private Enemy_1Center enemy1Center;
    protected override void Reset_LoadObjectCenter() => enemy1Center = transform.parent.GetComponent<Enemy_1Center>();

    #endregion
    protected override List<Transform> GetPoolList() => EnemyPoolObject.Instance.poolList;
    
    protected override bool CanDespawn() => enemy1Center.health.IsDead();
}