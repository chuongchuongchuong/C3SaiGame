using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid1DamageSender : BaseDamageSender
{
    protected override void ResetValues_Awake()
    {
        damage = 8;
    }
}