using ChuongLibrary.Game2D;
using UnityEngine;

public class JunkSpawner : BaseSpawn
{
    private float _spawnRate = 2; // Spawn speed
    private float _lastTimeSpawned;
    public int spawnedCount;

    private Vector3 spawnPosition;
    private Quaternion spawnRotation;
    private Vector3 targetPosition;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform junkPrefab;

    protected override void Reset_LoadComponents()
    {
        _camera = Camera.main;
    }

    protected override bool CanSpawn()
    {
        if (spawnedCount == 9) return false;
        // if not pressin left click, nothing
        //if (InputManager.Instance.onFiring != 1) return false;
        // if pressin left click, but not enough the cooldown time, nothing
        if (Time.time - _lastTimeSpawned < _spawnRate) return false;

        return true;
    }

    protected override void Spawn()
    {
        GetRandomJunk();
        GetARandomSpawnPosition();
        GetTheSpawnRotation();
        ScriptJunkPoolObject.Instance.Spawn(junkPrefab, spawnPosition, spawnRotation);
        _lastTimeSpawned = Time.time;
        spawnedCount++;
    }

    private void GetRandomJunk()
    {
        JunkList.Instance.GetRandomPrefab();
        junkPrefab = JunkList.Instance.prefab;
    }

    private void GetARandomSpawnPosition()
    {
        spawnPosition = GetRandom.RandomPointOutsideScreen(_camera);
    }

    private void GetTheSpawnRotation()
    {
        targetPosition = GetRandom.RandomPositionInCircle(_camera.transform.position, 3f);
        spawnRotation = LookAtTargetClass.LookAtTarget(spawnPosition, targetPosition);
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(targetPosition, 0.3f);
        Gizmos.DrawSphere(spawnPosition, 0.3f);
    }*/
}