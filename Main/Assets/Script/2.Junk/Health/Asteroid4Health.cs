using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid4Health : BaseAsteroidHealth
{
    protected override void Awake_ResetValues()
    {
        var takeData = Resources.Load<AsteroidData>(StringKeeper.AsteroidDataPath);
        maxHealth = takeData.asteroid[3].asteroidHealth;
        base.Awake_ResetValues();
    }
}