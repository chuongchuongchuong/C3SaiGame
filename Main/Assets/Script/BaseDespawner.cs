using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDespawner : ChuongMonoWithoutSingleton
{
    protected void Update()
    {
        if (!CanDespawn()) return;
        Despawn();
    }
    
    // @formatter:off
    protected virtual bool CanDespawn() => false;
    protected virtual void Despawn(){}
    
    // @formatter:on
}
