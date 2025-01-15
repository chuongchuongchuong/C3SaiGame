using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : BaseFlyStraight
{
    protected override void ResetValues_Awake()
    {
        speed = Resources.Load<ShipData>(StringKeeper.MainShipDataPath).bulletSpeed;
        direction = Vector2.right;
    }
}