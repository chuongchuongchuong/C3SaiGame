using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class BaseCollider : ChuongPrefabs
{
    [SerializeField] protected BaseDamageSender damageSender;
    private DamageReceiver damageReceiver;

    [SerializeField] protected Looter looter;
    private PickableItem pickableItem;

    protected override void LoadComponents_ResetInPrefab()
    {
        damageSender = GetComponent<BaseDamageSender>();
        looter = GetComponent<Looter>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (CanSendDamage(hitInfo)) SendDamage(damageReceiver);


        if (CanLoot(hitInfo)) LootItem(pickableItem);
    }

    protected virtual bool CanSendDamage(Collider2D hitInfo)
    {
        if (damageSender == null) return false; // this object has DamageSender?
        damageReceiver = hitInfo.GetComponent<DamageReceiver>();
        if (damageReceiver == null) return false; // hit Object receive damage?

        return true;
    }
    protected virtual void SendDamage(DamageReceiver damageReceiver) => damageSender.SendDamage(damageReceiver.health);
    
    
    protected virtual bool CanLoot(Collider2D hitInfo)
    {
        if(looter == null) return false;
        pickableItem = hitInfo.GetComponent<PickableItem>();
        if(pickableItem == null) return false;
        
        Debug.Log(pickableItem.name);

        return true;
    }

    protected virtual void LootItem(PickableItem pickableItem) => looter.Loot(pickableItem);
}