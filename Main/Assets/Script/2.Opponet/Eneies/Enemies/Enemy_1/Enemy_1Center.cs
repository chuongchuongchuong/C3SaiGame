using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy_1Center : MonoBehaviour
{
    public EnemyMovement movement;
    public EnemyShooting shooting;
    public Enemy_1Health health;
    public EnemyDespawn despawn;

    private void Reset()
    {
        movement = GetComponentInChildren<EnemyMovement>();
        shooting = GetComponentInChildren<EnemyShooting>();
        health = GetComponentInChildren<Enemy_1Health>();
        despawn = GetComponentInChildren<EnemyDespawn>();
    }
}