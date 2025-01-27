using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseListTransform : BaseList<Transform>
{
    public Transform prefab;
    protected override void Reset_LoadObjects()
    {
        foreach (Transform child in transform)
        {
            List.Add(child);
        }


        GetPrefabByIndex(index);
    }
    
    protected void GetPrefabByIndex(int index) => prefab=List[index-1];
}
