using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseList<T> : ChuongMonoSingleton<T> where T : BaseList<T>
{
    public List<Transform> prefabsList;
    public int index = 1;
    public Transform prefab;


    protected override void Reset_LoadObjects()
    {
        //Load weaponList
        foreach (Transform child in transform)
        {
            prefabsList.Add(child);
        }


        GetWeaponByIndex(index);
    }

    private void FixedUpdate()
    {
        UpdateIndex();
        GetWeaponByIndex(index);
    }

    private void GetWeaponByIndex(int index) => prefab = prefabsList[index - 1];

    // @formatter:off
    protected virtual void UpdateIndex(){}
    // @formatter:on
}