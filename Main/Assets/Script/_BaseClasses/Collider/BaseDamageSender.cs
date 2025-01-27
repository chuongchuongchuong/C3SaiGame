using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDamageSender : ChuongMono
{
    [Header("Base Damage Sender")]
    [SerializeField] protected int damage; //child class need to set value
    [SerializeField] protected Transform explosionPrefab = null; // component that child class need to set

    public virtual void SendDamage(BaseHealth health)
    {
        health.TakeDamage(damage);
        InstantiateExplosion();
    }

    private void InstantiateExplosion()
    {
        if (explosionPrefab == null) return;
        var explosion = Instantiate(explosionPrefab, transform.parent.position, Quaternion.identity);
        Destroy(transform.parent.gameObject);
        Destroy(explosion.gameObject, 3f);
    }
}