using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class BaseDamageSender : ChuongMono
{
    [Header("Base Damage Sender")] [SerializeField]
    protected int damage; //child class need to set value
    [SerializeField] protected DamageReceiver hitInfoDamageReceiver;

    protected override void Awake_ResetValues()
    {
        base.Awake_ResetValues();
        damage = SetDamage();
    }
    
    protected abstract int SetDamage();
    protected abstract BaseDespawn GetDespawn();

    protected virtual void OnTriggerEnter2D(Collider2D hitFo)
    {
        if (!CansendDamage(hitFo)) return;
        SendDamage(hitInfoDamageReceiver.health);
        DespawnThisObject();
    }

    protected virtual bool CansendDamage(Collider2D hitInfo)
    {
        hitInfoDamageReceiver = hitInfo.GetComponent<DamageReceiver>();
        return hitInfoDamageReceiver != null;
    }

    public virtual void SendDamage(BaseHealth health) => health.TakeDamage(damage);

    protected virtual void DespawnThisObject()
    {
        var despawn = GetDespawn();   
        if (despawn != null) despawn.Despawn(transform.parent, despawn.GetPoolList());
    }
}