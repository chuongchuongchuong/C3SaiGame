using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemFromInventory : BaseSpawn
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
        this.Spawn((equipment));
    }

    public Transform Spawn(Equipment equipment)
    {
        var dropItem = GetPoolPattern().Spawn(GetPrefab(equipment), GetSpawnPosition(), GetSpawnRotation());
        if (dropItem != null)
            dropItem.GetComponent<EquipmentCenter>().equipmentInfo = equipment;

        return dropItem;
    }

    protected override BasePoolPattern GetPoolPattern() => PoolObjectCenter.Instance.dropItem;
    protected override Transform GetPrefab() => null;

    protected Transform GetPrefab(Equipment equipment) => equipment.itemProfile.prefab;

    protected override Vector3 GetSpawnPosition() => transform.root.position + Vector3.up * 2;

    protected override Quaternion GetSpawnRotation() => Quaternion.identity;
}