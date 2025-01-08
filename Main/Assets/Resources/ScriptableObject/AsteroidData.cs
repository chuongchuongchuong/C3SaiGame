using UnityEngine;
using System;
using System.Collections.Generic;


[CreateAssetMenu(menuName = "Asteroid")]
public class AsteroidData : ScriptableObject
{
    public List<AsteroidDataStruct> asteroid;
}

[Serializable]
public struct AsteroidDataStruct
{
    public int moveSpeed;
    public float asteroidSize;
    public int asteroidHealth;
}
