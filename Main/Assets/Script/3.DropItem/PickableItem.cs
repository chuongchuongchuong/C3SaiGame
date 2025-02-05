using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : ChuongMono
{
    #region Get Object Center

    public EquipmentCenter equipmentCenter;
    protected override void LoadObjectCenter() => equipmentCenter = transform.parent.GetComponent<EquipmentCenter>();

    #endregion
}