using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDamageSender : ChuongPrefabs
{
    [SerializeField] private BaseDamageReceiver damageReceiver;

    public void DOSendDamage(Transform hitInfo, int damage)
    {
        if (!CanSendDamage(hitInfo)) return;
        SendDamage(damage);
        AfterSendDamage();
    }

    protected virtual bool CanSendDamage(Transform hitInfo)
    {
        damageReceiver = hitInfo.GetComponentInChildren<BaseDamageReceiver>();
        return damageReceiver != null;
    }

    protected virtual void SendDamage(int damage)
    {
        damageReceiver.health.TakeDamage(damage);
    }

    protected virtual void AfterSendDamage()
    {
        Destroy(transform.parent.gameObject);
    }
}