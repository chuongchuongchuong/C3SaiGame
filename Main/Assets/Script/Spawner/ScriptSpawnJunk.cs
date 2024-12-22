using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using ChuongLibrary.GameDev;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class ScriptSpawnJunk : BaseSpawner<ScriptSpawnJunk>
{
    private float _spawnRate; // Spawn speed
    private float _lastTimeSpawned;

    private Vector3 spawnPosition;
    private Quaternion spawnRotation;
    private Vector3 targetPosition;
    [SerializeField] private Camera _camera;

    protected override void ResetValues()
    {
        _spawnRate = .5f;
    }

    protected override void LoadComponents()
    {
        _camera = Camera.main;
    }

    protected override bool CanSpawn()
    {
        /*// if not pressin left click, nothing
        if (ScriptInputManager.Instance.onFiring != 1) return false;
        // if pressin left click, but not enough the cooldown time, nothing*/
        if (Time.time - _lastTimeSpawned < _spawnRate) return false;

        return true;
    }

    protected override void Spawn()
    {
        GetRandomPosition();
        GetTheSpawnRotation();
        ScriptJunkPoolObject.Instance.Spawn(spawnPosition, spawnRotation);
        _lastTimeSpawned = Time.time;
    }

    private void GetRandomPosition()
    {
        spawnPosition = Game2D.RandomPointOutsideScreen(_camera);
    }

    private void GetTheSpawnRotation()
    {
        targetPosition = Game2D.RandomPositionInCircle(_camera.transform.position, 3f);
        spawnRotation = Game2D.LookAtTarget(spawnPosition, targetPosition);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(targetPosition, 0.3f);
    }
}