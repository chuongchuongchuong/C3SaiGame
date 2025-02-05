using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1DamageSender : BaseDamageSender
{
    #region Get Object Center

    [SerializeField] private Bullet_1center bullet_1center;
    protected override void LoadObjectCenter() => bullet_1center ??= transform.parent.GetComponent<Bullet_1center>();

    #endregion
    

    protected override int SetDamage() => 10;

    protected override BaseDespawn GetDespawn() => bullet_1center.Despawn;
}