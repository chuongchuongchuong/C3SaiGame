using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class BaseCollider : ChuongMono
{
    [Header("Base Collider")]
    [SerializeField] protected BaseDamageSender damageSender;

    private DamageReceiver hitInfoDamageReceiver;


    protected override void LoadComponents_ResetInPrefab()
    {
        damageSender = GetComponent<BaseDamageSender>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (!CanSendDamage(hitInfo)) return;
        SendDamage(hitInfoDamageReceiver);
    }

    protected virtual bool CanSendDamage(Collider2D hitInfo)
    {
        if (damageSender == null) return false; // this object has DamageSender?
        hitInfoDamageReceiver = hitInfo.GetComponent<DamageReceiver>();
        if (hitInfoDamageReceiver == null) return false; // hit Object receive damage?

        return true;
    }

    protected virtual void SendDamage(DamageReceiver damageReceiver) => damageSender.SendDamage(damageReceiver.health);
}