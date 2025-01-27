using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid2Center : BaseAsteroidCenter
{
    protected override float GetAsteroidSize() =>
        Resources.Load<AsteroidData>(StringKeeper.AsteroidDataPath).asteroid[1].asteroidSize;
}