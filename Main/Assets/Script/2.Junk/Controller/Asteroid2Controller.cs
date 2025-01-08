using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid2Controller : BaseAsteroidController
{
    protected override float GetAsteroidSize() =>
        Resources.Load<AsteroidData>("ScriptableObject/AsteroidData").asteroid[1].asteroidSize;
}