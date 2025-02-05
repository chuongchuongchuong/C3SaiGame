using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCenter : MonoBehaviour
{
    public ExplosionDespawn Despawn;

    private void Reset()
    {
        Despawn = GetComponentInChildren<ExplosionDespawn>();
    }
}
