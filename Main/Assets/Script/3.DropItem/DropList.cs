using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropList : BaseList<DropItemData>
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

    public DropItemData DropItemData;

    protected override void LoadObjects_Reset()
    {
        DropItemData = Resources.Load<DropItemData>(StringsKeeper.DropItemDataPath);
    }


    /*public Transform DropItem()
    {
        var ramdomNum = Random.Range(0f, 100f);
        for (var i = prefabsList.Count - 1; i >= 0; i--)
        {
            if (ramdomNum <= prefabsList[i].droprate) return prefabsList[i];
        }
    }*/
}