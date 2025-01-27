using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1Center : MonoBehaviour
{
    public EnemyMovement movement;
    public EnemyShooting shooting;
    public Enemy_1Health health;
    public Enemy_1Death death;

    private void Reset()
    {
        movement = GetComponentInChildren<EnemyMovement>();
        shooting = GetComponentInChildren<EnemyShooting>();
        health = GetComponentInChildren<Enemy_1Health>();
        death = GetComponentInChildren<Enemy_1Death>();
    }
}