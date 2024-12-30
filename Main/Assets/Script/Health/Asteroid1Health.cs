using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid1Health : BaseHealth
{
    protected override void ResetValues_Awake()
    {
        maxHealth = 10;
        base.ResetValues_Awake();
    }
}
