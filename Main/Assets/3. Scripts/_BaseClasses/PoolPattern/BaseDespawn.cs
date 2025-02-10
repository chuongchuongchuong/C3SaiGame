using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDespawn : ChuongMono
{
    public abstract List<Transform> GetPoolList();

    protected virtual void Update() => IfCanDespawnThenDespawn();

    protected virtual void IfCanDespawnThenDespawn()
    {
        if (CanDespawn()) Despawn(transform.parent, GetPoolList());
    }

    protected abstract bool CanDespawn();

    public virtual void Despawn(Transform obj, List<Transform> poolList)
    {
        poolList.Add(obj);
        obj.gameObject.SetActive(false);
    }

    public virtual void Despawn()
    {
        GetPoolList().Add(transform.parent);
        transform.parent.gameObject.SetActive(false);
    }
}