using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditorInternal;
using UnityEngine;

public class AsteroidDespawn : BaseDespawn
{
    
    #region Get the Asteroid Center
    [SerializeField] private BaseAsteroidCenter asteroidCenter;
    protected override void Reset_LoadObjectCenter() => asteroidCenter = GetComponentInParent<BaseAsteroidCenter>();

    #endregion
    
    private Camera _mainCamera;
    [SerializeField] private float despawnDistance;

    protected override List<Transform> GetPoolList() => ScriptJunkPoolObject.Instance.poolList;

    protected override void Awake_ResetValues()
    {
        base.Awake_ResetValues();
        despawnDistance = 25f;
    }

    protected override void Awake_Others()
    {
        _mainCamera = Camera.main;
    }

    protected override void Update() => CanDespawnThenDespawn();

    protected void CanDespawnThenDespawn()
    {
        if (CanDespawn()) Despawn();
    }

    protected override bool CanDespawn()
    {
        if (Vector2.Distance(transform.parent.position, _mainCamera.transform.position) < despawnDistance)
            return false;
        
        if (!asteroidCenter.health.IsDead()) return false;
        
        return true;
    }

    public override void Despawn()
    {
        JunkCenter.Instance.junkSpawner.spawnedCount--;
        base.Despawn();
    }
    
    
    
    
    protected virtual void OnDisable() => OnDeathDrop();

    protected virtual void OnDeathDrop()
    {
        var dropPrefab = DropList.Instance.DropItem();
        if (dropPrefab == null) return;
        DropItemPoolObject.Instance.Spawn(dropPrefab.transform,
            transform.position, Quaternion.identity);
    }
}