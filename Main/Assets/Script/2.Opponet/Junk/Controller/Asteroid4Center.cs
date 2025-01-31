using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid4Center : BaseAsteroidCenter
{
    protected override float GetAsteroidSize() =>
        Resources.Load<AsteroidData>(StringKeeper.AsteroidDataPath).asteroid[3].asteroidSize;
}