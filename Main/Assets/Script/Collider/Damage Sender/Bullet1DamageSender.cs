using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1DamageSender : BaseDamageSender
{
    protected override void ResetValues_Awake()
    {
        damage = 10;
    }
}
