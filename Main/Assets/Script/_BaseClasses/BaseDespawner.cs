using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDespawner : ChuongPrefabs
{
    protected MonoBehaviour forGetPoollist;
    protected List<Transform> poolList;

    protected virtual void Update()
    {
        if (!CanDespawn()) return;
        Despawn();
    }
    
    // @formatter:off
    protected virtual bool CanDespawn() => false;
    // @formatter:on
    public virtual void Despawn()
    {
        poolList.Add(transform.parent);
        transform.parent.gameObject.SetActive(false);
    }
}