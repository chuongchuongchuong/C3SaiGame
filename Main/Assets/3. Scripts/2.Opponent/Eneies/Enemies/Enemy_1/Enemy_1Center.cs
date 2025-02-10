using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy_1Center : MonoBehaviour
{
    public Enemy_1Rotation modelRotation;
    public Enemy_1OnAppear modelOnAppear;
    public Enemy1Movement_FollowTarget movement_FollowTarget;
    public Enemy1Movement_Forward Movement_Forward;
    public EnemyShooting shooting;
    public Enemy_1Health health;
    public EnemyDespawn despawn;

    private void Reset()
    {
        modelRotation = GetComponentInChildren<Enemy_1Rotation>();
        modelOnAppear = GetComponentInChildren<Enemy_1OnAppear>();
        movement_FollowTarget = GetComponentInChildren<Enemy1Movement_FollowTarget>();
        Movement_Forward = GetComponentInChildren<Enemy1Movement_Forward>();
        shooting = GetComponentInChildren<EnemyShooting>();
        health = GetComponentInChildren<Enemy_1Health>();
        despawn = GetComponentInChildren<EnemyDespawn>();
    }
}