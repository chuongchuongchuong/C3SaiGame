using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentCenter : MonoBehaviour
{
    public DropItemDespawn despawner;
    public Equipment equipmentInfo;

    private void Reset()
    {
        despawner = GetComponentInChildren<DropItemDespawn>();
    }
}
