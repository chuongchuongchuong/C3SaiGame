using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : ChuongPrefabs
{
    public BaseDespawn despawner;
    public ItemName itemName;

    protected override void LoadComponents_ResetInPrefab()
    {
        despawner = transform.parent.GetComponentInChildren<BaseDespawn>();
    }

    protected override void ResetValues_Awake()
    {
        //itemName = (ItemName)System.Enum.Parse(typeof(ItemName),transform.parent.name.Replace("(clone)",""));
    }
}