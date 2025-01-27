using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid1Center : BaseAsteroidCenter
{
    protected override float GetAsteroidSize() =>
        Resources.Load<AsteroidData>(StringKeeper.AsteroidDataPath).asteroid[0].asteroidSize;
    
    public JunkFly junkFly;
    public Asteroid1Health asteroid1Health;
}