using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid1Controller : BaseAsteroidController
{
    protected override float GetAsteroidSize() =>
        Resources.Load<AsteroidData>(StringsKeeper.AsteroidDataPath).asteroid[0].asteroidSize;
}