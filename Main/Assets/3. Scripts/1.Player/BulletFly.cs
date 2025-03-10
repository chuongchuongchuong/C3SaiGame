using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : BaseFlyStraight
{
    protected override void Awake_ResetValues()
    {
        speed = Resources.Load<ShipData>(StringKeeper.MainShipDataPath).bulletSpeed;
        direction = Vector2.right;
    }
}