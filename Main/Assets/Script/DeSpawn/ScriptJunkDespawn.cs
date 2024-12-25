using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditorInternal;
using UnityEngine;

public class ScriptJunkDespawn : BaseDespawner
{
    private Camera _mainCamera;
    [SerializeField] private float despawnDistance;

    protected override void Awake_ResetValues()
    {
        poolList = ScriptJunkPoolObject.Instance.poolList;
    }

    protected override void Awake_LoadComponents()
    {
        _mainCamera = Camera.main;
    }


    protected override bool CanDespawn()
    {
        if (Vector2.Distance(transform.parent.position, _mainCamera.transform.parent.position) <
            despawnDistance) return false;
        return true;
    }

    protected override void Update()
    {
        //Debug.Log(CanDespawn());
        if (!CanDespawn()) return;
        base.Despawn();
    }
}