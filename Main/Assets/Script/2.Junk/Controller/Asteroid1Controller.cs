using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid1Controller : BaseAsteroidController
{
    protected override float GetAsteroidSize() =>
        Resources.Load<AsteroidData>("ScriptableObject/AsteroidData").asteroid[0].asteroidSize;
}