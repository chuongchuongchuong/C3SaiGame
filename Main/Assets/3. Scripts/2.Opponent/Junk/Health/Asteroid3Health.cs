using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid3Health : BaseHealth
{
    protected override void Awake_ResetValues()
    {
        var takeData = Resources.Load<AsteroidData>(StringKeeper.AsteroidDataPath);
        maxHealth = takeData.asteroid[2].asteroidHealth;
        base.Awake_ResetValues();
    }
}