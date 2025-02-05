using ChuongLibrary.Game2D;
using UnityEngine;

public class JunkSpawner : BaseSpawn
{
    private float _spawnRate = 2; // Spawn speed
    private float _lastTimeSpawned;
    public int spawnedCount;

    [SerializeField] private Camera _camera;
    [SerializeField] private Transform junkPrefab;

    protected override void Reset_LoadComponents()
    {
        _camera = Camera.main;
    }

    protected override BasePoolPattern GetPoolPattern() => PoolObjectCenter.Instance.junk;

    protected override void Spawner()
    {
        if (CanSpawn()) Spawn();
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

    public override Transform Spawn()
    {
        var junkPrefab = JunkList.Instance.GetRandomPrefab();
        var spawnedPosition = GetRandom.RandomPointOutsideScreen(_camera);
        var targetPoint = GetRandom.RandomPositionInCircle(_camera.transform.position, 3f);
        var rotation = LookAtTargetClass.LookAtTarget(spawnedPosition, targetPoint);
        var spawnedJunk= GetPoolPattern().Spawn(junkPrefab, spawnedPosition, rotation);
        _lastTimeSpawned = Time.time;
        spawnedCount++;
        
        return spawnedJunk;
    }

    protected override Transform GetPrefab() => null;

    protected override Vector3 GetSpawnPosition() => new();

    protected override Quaternion GetSpawnRotation() => new();

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(targetPosition, 0.3f);
        Gizmos.DrawSphere(spawnPosition, 0.3f);
    }*/
}