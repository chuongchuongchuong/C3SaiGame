using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1Collider : BaseCollider
{
    protected override void ResetValues_Awake()
    {
        ResetRigid();
        ResetCollider();
    }

    private void ResetRigid()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    private void ResetCollider()
    {
        var capsuleCollider = GetComponent<CapsuleCollider2D>();
        capsuleCollider.isTrigger = true;
        capsuleCollider.size = new Vector2(0.1f, 0.74f);
    }
}