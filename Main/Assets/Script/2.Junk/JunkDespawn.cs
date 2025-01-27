using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditorInternal;
using UnityEngine;

public class JunkDespawn : BaseDespawn
{
    private Camera _mainCamera;
    [SerializeField] private float despawnDistance;

    protected override void Awake_ResetValues()
    {
        despawnDistance = 25f;
        poolList = ScriptJunkPoolObject.Instance.poolList;
    }

    protected override void Awake_Others()
    {
        _mainCamera = Camera.main;
    }
    
    protected override void Update()
    {
        //Debug.Log(CanDespawn());
        if (!CanDespawn()) return;
        Despawn();
    }
    
    protected override bool CanDespawn() =>
        Vector2.Distance(transform.parent.position, _mainCamera.transform.position) >=
        despawnDistance;

    public override void Despawn()
    {
        JunkCenter.Instance.junkSpawner.spawnedCount--;
        base.Despawn();
    }
}