using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseListTransform : BaseList<Transform>
{
    protected override void Reset_LoadObjects()
    {
        foreach (Transform child in transform)
        {
            List.Add(child);
        }
    }
}
