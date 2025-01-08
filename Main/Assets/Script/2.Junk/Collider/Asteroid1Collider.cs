using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid1Collider : BaseCollider
{
    protected override void ResetValues_Awake()
    {
        var circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.radius = 0.15f;
        circleCollider.isTrigger = true;
    }
}
