using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid3Controller : BaseAsteroidController
{
    protected override float GetAsteroidSize() =>
        Resources.Load<AsteroidData>(StringsKeeper.AsteroidDataPath).asteroid[2].asteroidSize;
}