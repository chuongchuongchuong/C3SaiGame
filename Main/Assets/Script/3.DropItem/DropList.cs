using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropList : BaseList<DropItemDataStruct>
{
    #region Singleton Implementation

    public static DropList Instance { get; private set; }

    protected override void GuaranteeSingleton()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning("More than one " + GetType().Name + " in scene.");
            return;
        }

        Instance = this;
    }

    #endregion

    protected override void Reset_LoadObjects()
    {
        List = Resources.Load<DropItemData>(StringKeeper.DropItemDataPath).ItemDataList;
    }


    public GameObject DropItem()
    {
        var ramdomNum = Random.Range(0f, 100f);
        Debug.Log(ramdomNum);
        for (var i = List.Count - 1; i >= 0; i--)
        {
            if (ramdomNum <= List[i].dropRate) return List[i].prefab;
        }

        return null;
    }
}