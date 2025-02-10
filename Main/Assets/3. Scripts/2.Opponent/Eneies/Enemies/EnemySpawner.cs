using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChuongLibrary.Game2D;

public class EnemySpawner : BaseSpawn
{
    private float _spawnRate = 1; // Spawn speed
    private float _lastTimeSpawned;
    public int spawnedCount;

    [SerializeField] private Camera _camera;
    [SerializeField] private Transform enemyPrefab;
    [SerializeField] private OpponentCenter opponentCenter;

    protected override void Reset_LoadComponents()
    {
        _camera = Camera.main;
        opponentCenter = GetComponentInParent<OpponentCenter>();
    }

    protected override BasePoolPattern GetPoolPattern() => PoolObjectCenter.Instance.enemy;

    protected override bool CanSpawn()
    {
        if (spawnedCount == 9) return false;
        // if not pressin left click, nothing
        //if (InputManager.Instance.onFiring != 1) return false;
        // if pressin left click, but not enough the cooldown time, nothing
        if (Time.time - _lastTimeSpawned < _spawnRate) return false;

        return true;
    }

    protected override void Spawner()
    {
        base.Spawner();
        _lastTimeSpawned = Time.time;
        spawnedCount++;
    }

    protected override Transform GetPrefab() => opponentCenter.enemyList.List[0];
    protected override Vector3 GetSpawnPosition() => GetRandom.RandomPointOutsideScreen(_camera);

    protected override Quaternion GetSpawnRotation() => Quaternion.identity;
}