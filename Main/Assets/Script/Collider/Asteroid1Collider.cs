using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid1Collider : BaseCollider
{
    protected override void ResetValues_Awake()
    {
        ResetRigid();
        ResetCollider();
    }

    private void ResetRigid()
    {
        var rigid = GetComponent<Rigidbody2D>();
        rigid.isKinematic = true;
    }

    private void ResetCollider()
    {
        var colllider = GetComponent<CircleCollider2D>();
        colllider.isTrigger = true;
        colllider.radius = .9f;
    }
}