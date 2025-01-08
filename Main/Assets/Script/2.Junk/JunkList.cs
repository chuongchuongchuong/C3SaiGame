using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkList : BaseList<JunkList>
{
    public Transform GetRandomPrefab()
    {
        GetPrefabByIndex(Random.Range(1, prefabsList.Count + 1));
        //Debug.Log(prefabsList.Count);
        return prefab;
    }
}