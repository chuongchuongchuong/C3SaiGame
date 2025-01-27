using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : ChuongMono
{
    public BaseDespawn despawner;
    public EquipmentInfo equipmentInfo;

    protected override void Reset_LoadComponents()
    {
        despawner = transform.parent.GetComponentInChildren<BaseDespawn>();
        equipmentInfo= transform.parent.GetComponent<EquipmentInfo>();
    }

    protected override void Awake_ResetValues()
    {
        //itemName = (ItemName)System.Enum.Parse(typeof(ItemName),transform.parent.name.Replace("(clone)",""));
    }
}