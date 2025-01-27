using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAsteroidHealth : BaseHealth
{
    protected void OnEnable()
    {
        healthPoint = maxHealth;
    }
}
