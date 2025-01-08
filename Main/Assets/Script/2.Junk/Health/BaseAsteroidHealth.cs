using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAsteroidHealth : BaseHealth
{
    protected override void OnEnable()
    {
        healthPoint = maxHealth;
    }
}
