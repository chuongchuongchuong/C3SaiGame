using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDespawn : ChuongMono
{
    //protected MonoBehaviour forGetPoollist;
    protected List<Transform> poolList;

    protected virtual void Update()
    {
        if (!CanDespawn()) return;
        Despawn();
    }
    protected virtual bool CanDespawn() => false;
    public virtual void Despawn()
    {
        poolList.Add(transform.parent);
        transform.parent.gameObject.SetActive(false);
    }
}