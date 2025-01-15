using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1Collider : BaseCollider
{
    protected override void ResetValues_Awake() => ResetCollider();

    private void ResetCollider()
    {
        var capsuleCollider = GetComponent<CapsuleCollider2D>();
        capsuleCollider.isTrigger = true;
        capsuleCollider.direction = CapsuleDirection2D.Horizontal;
        capsuleCollider.size = new Vector2(0.49f, 0.26f);
        
    }
}