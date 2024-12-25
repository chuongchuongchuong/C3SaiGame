using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid1Health : BaseHealth
{
    protected override void Awake_ResetValues()
    {
        maxHealth = 10;
        base.Awake_ResetValues();
    }
}
