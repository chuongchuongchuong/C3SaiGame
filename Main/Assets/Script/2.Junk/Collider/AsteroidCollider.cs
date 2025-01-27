using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollider : BaseCollider
{
    //[SerializeField] protected new BaseDamageSender damageSender;
    protected override void Awake_ResetValues() => ResetCollider();
    
    private void ResetCollider()
    {
        var circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.radius = 0.15f;
        circleCollider.isTrigger = true;
    }
}
