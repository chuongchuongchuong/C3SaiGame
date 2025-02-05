using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Bullet_1center : MonoBehaviour
{
    public Bullet1Despawn Despawn;
    public BulletFly bulletFly;
    public Bullet1DamageSender damageSender;

    private void Reset()
    {
        Despawn = GetComponentInChildren<Bullet1Despawn>();
        bulletFly = GetComponentInChildren<BulletFly>();
        damageSender = GetComponentInChildren<Bullet1DamageSender>();
    }
}