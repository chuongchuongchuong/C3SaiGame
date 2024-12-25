using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BulletImpact : ChuongPrefabs
{
    [SerializeField] private CapsuleCollider2D _collider2D;
    [SerializeField] private Rigidbody2D _rigidbody;

    private int Damage = 5;

    protected override void Awake_LoadComponents()
    {
        LoadCapsuleCollider2D();
        LoadRigidbody2D();
    }

    private void LoadCapsuleCollider2D()
    {
        _collider2D = GetComponent<CapsuleCollider2D>();
        _collider2D.size = new Vector2(0.21f, 0.48f);
        _collider2D.isTrigger = true;
    }

    private void LoadRigidbody2D()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.isKinematic = true;
    }

    private void OnTriggerEnter(Collider hitInfo)
    {
        Debug.Log("Ok");
        GetComponent<BaseDamageSender>().DOSendDamage(hitInfo.transform, Damage);
    }
}