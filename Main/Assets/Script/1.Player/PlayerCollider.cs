using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : BaseCollider
{
    protected override void ResetValues_Awake()
    {
        var circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.radius = 0.2f;
    }
}
