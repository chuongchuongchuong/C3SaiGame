using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSpawner<T> : ChuongMonoSingleton<T> where T : BaseSpawner<T>
{
    protected virtual void Update()
    {
        if (CanSpawn())
            Spawn();
    }

    // @formatter:off
    protected virtual bool CanSpawn(){return false;}
    protected virtual void Spawn(){}
    // @formatter:on
}