using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSpawn : ChuongMono
{
    protected virtual void Update()
    {
        if (CanSpawn()) Spawn();
    }

    // @formatter:off
    protected virtual bool CanSpawn(){return false;}
    protected virtual void Spawn(){}
    // @formatter:on
}