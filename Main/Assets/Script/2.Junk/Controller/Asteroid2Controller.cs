using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid2Controller : BaseAsteroidController
{
    protected override float GetAsteroidSize() =>
        Resources.Load<AsteroidData>(StringsKeeper.AsteroidDataPath).asteroid[1].asteroidSize;
}