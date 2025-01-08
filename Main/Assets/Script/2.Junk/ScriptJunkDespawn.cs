using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditorInternal;
using UnityEngine;

public class ScriptJunkDespawn : BaseDespawner
{
    private Camera _mainCamera;
    [SerializeField] private float despawnDistance;

    protected override void ResetValues_Awake()
    {
        despawnDistance = 25f;
        poolList = ScriptJunkPoolObject.Instance.poolList;
    }

    protected override void LoadComponentsOutsidePrefab_Awake()
    {
        _mainCamera = Camera.main;
    }


    protected override bool CanDespawn() =>
        Vector2.Distance(transform.parent.position, _mainCamera.transform.parent.position) >=
        despawnDistance;

    protected override void Update()
    {
        //Debug.Log(CanDespawn());
        if (!CanDespawn()) return;
        Despawn();
    }

    public override void Despawn()
    {
        ScriptSpawnJunk.Instance.spawnedCount--;
        base.Despawn();
    }
}