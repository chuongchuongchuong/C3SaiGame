using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid3Health : BaseAsteroidHealth
{
    protected override void ResetValues_Awake()
    {
        var takeData = Resources.Load<AsteroidData>(StringsKeeper.AsteroidDataPath);
        maxHealth = takeData.asteroid[2].asteroidHealth;
        base.ResetValues_Awake();
    }
}