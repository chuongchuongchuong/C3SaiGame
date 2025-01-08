using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid1Health : BaseAsteroidHealth
{
    protected override void ResetValues_Awake()
    {
        var takeData = Resources.Load<AsteroidData>("ScriptableObject/AsteroidData");
        maxHealth = takeData.asteroid[0].asteroidHealth;
        base.ResetValues_Awake();
    }
    
}