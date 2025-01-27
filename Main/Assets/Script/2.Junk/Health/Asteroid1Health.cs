using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid1Health : BaseAsteroidHealth
{
    protected override void Awake_ResetValues()
    {
        var takeData = Resources.Load<AsteroidData>(StringKeeper.AsteroidDataPath);
        maxHealth = takeData.asteroid[0].asteroidHealth;
        base.Awake_ResetValues();
    }
    
}