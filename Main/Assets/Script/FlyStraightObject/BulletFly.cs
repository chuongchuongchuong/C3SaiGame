using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : BaseFlyStraight
{
    protected override void ResetValues_Awake()
    {
        speed = Resources.Load<ShipData>("MainShip").bulletSpeed;
        direction=Vector2.right;
    }
}