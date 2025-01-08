using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseList<T> : ChuongMonoSingleton<T> where T : BaseList<T>
{
    public List<Transform> prefabsList;
    public int index = 1;
    public Transform prefab;


    protected override void LoadObjects_Reset()
    {
        foreach (Transform child in transform)
        {
            prefabsList.Add(child);
        }


        GetPrefabByIndex(index);
    }

    private void FixedUpdate()
    {
        UpdateIndex();
        GetPrefabByIndex(index);
    }

    protected void GetPrefabByIndex(int index) => prefab = prefabsList[index - 1];

    // @formatter:off
    protected virtual void UpdateIndex(){}
    // @formatter:on
}