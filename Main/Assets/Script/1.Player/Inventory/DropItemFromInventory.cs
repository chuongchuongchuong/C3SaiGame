using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemFromInventory : ChuongMono
{
    [SerializeField] private Inventory inventory;

    protected override void Reset_LoadComponents()
    {
        inventory = transform.parent.GetComponent<Inventory>();
    }

    [ContextMenu("DropEquipmentTest")]
    private void DropEquipment() => DropItem(inventory.equipments[0]);

    public void DropItem(Equipment equipment)
    {
        inventory.equipments.Remove(equipment);
        DropItemPoolObject.Instance.DropItemFromInventory(equipment, transform.root.position + Vector3.up * 2);
    }
}