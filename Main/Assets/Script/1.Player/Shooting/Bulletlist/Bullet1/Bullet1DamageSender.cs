using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1DamageSender : BaseDamageSender
{
    #region Get Object Center

    [SerializeField] private Bullet_1center bullet_1center;
    protected override void Reset_LoadObjectCenter() => bullet_1center = transform.parent.GetComponent<Bullet_1center>();

    #endregion
    
    
    protected override void Awake_ResetValues()
    {
        base.Awake_ResetValues();
        damage = 10;
    }

    protected override BaseDespawn GetDespawn() => bullet_1center.Despawn;
}