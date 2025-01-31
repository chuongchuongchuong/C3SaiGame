using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Asteroid1DamageSender : BaseDamageSender
{
    protected override void Awake_ResetValues()
    {
        damage = 8;
    }

    protected override BaseDespawn GetDespawn() => null;
}