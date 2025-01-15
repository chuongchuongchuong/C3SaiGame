using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1DamageSender : BaseDamageSender
{
    [SerializeField] private BaseDespawn _scriptBullet1Despawn;

    protected override void LoadComponents_ResetInPrefab()
    {
        _scriptBullet1Despawn = transform.parent.GetComponentInChildren<BaseDespawn>();
    }

    protected override void ResetValues_Awake()
    {
        damage = 10;
    }

    public override void SendDamage(BaseHealth health)
    {
        base.SendDamage(health);
        _scriptBullet1Despawn.Despawn();
    }
}