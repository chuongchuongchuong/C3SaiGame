using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDamageReceiver : ChuongPrefabs
{
    public BaseHealth health;

    protected override void Awake_LoadComponents()
    {
        health = GetComponent<BaseHealth>();
    }
}