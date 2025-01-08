using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public abstract class BaseCollider : ChuongPrefabs
{
    [SerializeField] protected BaseDamageSender damageSender;
    
    protected override void LoadComponents_ResetInPrefab()
    {
        damageSender = GetComponent<BaseDamageSender>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Debug.Log("enemy was hit");
        if (damageSender == null) return;// this object has damagesender?
        var damageReceiver = hitInfo.GetComponent<DamageReceiver>();
        if (damageReceiver == null) return; // hit Object receive damage?
        damageSender.SendDamage(damageReceiver.health);
    }
}