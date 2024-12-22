using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkFly : BaseFlyStraight
{
    protected override void ResetValues()
    {
        speed = 2f;
        direction = Vector2.right;
    }
}
