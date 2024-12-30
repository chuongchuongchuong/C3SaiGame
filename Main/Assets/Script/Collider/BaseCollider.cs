using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class BaseCollider : ChuongPrefabs
{
    [SerializeField] protected BaseDamageSender damageSender;

    //protected override Lo
    protected override void LoadComponents_ResetInPrefab()
    {
        damageSender = GetComponentInChildren<BaseDamageSender>();
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("enemy was hit");
        if (damageSender == null) return;// this object has damagesender?
        var health = hitInfo.transform.GetComponentInChildren<BaseHealth>();
        if (health == null) return; // hit Object has health?
        if (!health.isReceiveDamage) return; // hit object health receive damage?

        damageSender.SendDamage(health);
    }
}