using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDespawn : ChuongMono
{
    //protected MonoBehaviour forGetPoollist;
    protected List<Transform> poolList;

    protected override void Awake_ResetValues()
    {
        base.Awake_ResetValues();
        poolList = GetPoolList();
    }
    
    protected abstract List<Transform> GetPoolList();

    protected virtual void Update() => IfCanDespawnThenDespawn();
    protected virtual void IfCanDespawnThenDespawn()
    {
        if (CanDespawn()) Despawn();
    }
    protected abstract bool CanDespawn();
    public virtual void Despawn()
    {
        poolList.Add(transform.parent);
        transform.parent.gameObject.SetActive(false);
    }
}