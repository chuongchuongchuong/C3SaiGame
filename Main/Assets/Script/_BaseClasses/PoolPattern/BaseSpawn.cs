using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseSpawn : ChuongMono
{
    protected virtual void Update() => Spawner();

    protected virtual void Spawner()
    {
        if (CanSpawn()) Spawn();
    }

    // @formatter:off
    protected virtual bool CanSpawn()=> false;
    protected virtual void Spawn(){}
    // @formatter:on
}