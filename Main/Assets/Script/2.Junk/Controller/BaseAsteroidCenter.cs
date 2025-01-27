using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAsteroidCenter : ChuongMono
{
    protected override void Awake_ResetValues()
    {
        ResetRigid();
        ResetSize();
    }

    private void ResetRigid()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    private void ResetSize()
    {
        var asteroidSize = GetAsteroidSize();
        var temp = transform.localScale;
        temp.x *= asteroidSize;
        temp.y *= asteroidSize;
        transform.localScale = temp;
    }

    protected abstract float GetAsteroidSize();
}
