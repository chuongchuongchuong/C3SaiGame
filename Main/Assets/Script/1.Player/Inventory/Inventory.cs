using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : ChuongMono
{
    [SerializeField] protected int equipMaxSlot = 6;
    [SerializeField] protected int resourceMaxSlot = 7;
    [SerializeField] protected PlayerCenter playerCenter;
    

    [Header("Equipment")] [SerializeField] public List<Equipment> equipments;
    protected Equipment equipment;

    [Header("Resources")] [SerializeField] public List<Resource> resourceList;
    protected Resource resource;


    protected override void Reset_LoadComponents()
    {
        playerCenter = transform.parent.GetComponent<PlayerCenter>();
    }

    //[ContextMenu("Add Item")]
    //protected void Add() => AddItem(ItemName.Sword, 3);

    private bool IsTheEquipmentExistsInInventory(Item item)
    {
        equipment = equipments.Find((equipment) => equipment.itemProfile == item);
        return equipment != null;
    }

    private bool IsTheResourceExistsInInventory(Item item)
    {
        resource = resourceList.Find((equipment) => equipment.itemProfile == item);
        return resource != null;
    }

    #region AddItem

    public void AddAnEquipment(Item pickedItem)
    {
        if (equipments.Count == equipMaxSlot) return; //Nhiều nhất là 6 slot đồ
        if (IsTheEquipmentExistsInInventory(pickedItem)) return; //Nếu đồ này bị trùng thì sẽ ko add thêm nữa
        
        equipment = new Equipment()
        {
            itemProfile = pickedItem,
            level = playerCenter.playerCollider.pickableItem.equipmentInfo.equipment.level
        };
        equipments.Add(equipment); // Add thêm đồ vào equipments
        playerCenter.looter.canDespawnItem = true;
    }

    public void AddResource(Item pickedItem, int addAmount)
    {
        if (IsTheResourceExistsInInventory(pickedItem)) StackDeResourceIntoResourceList(addAmount);
        else AddNewResourceSlot(addAmount);
        return;

        void StackDeResourceIntoResourceList(int addAmount)
        {
            resource.stackCount += addAmount;
            playerCenter.looter.canDespawnItem = true;
        }

        void AddNewResourceSlot(int addAmount)
        {
            if (resourceList.Count == resourceMaxSlot) return; // nếu maxslot đã full thì ko thể thêm được nữa

            resource = new Resource
            {
                itemProfile = pickedItem,
                stackCount = addAmount
            };

            resourceList.Add(resource);
            Debug.Log("picked " + pickedItem.itemName);
            playerCenter.looter.canDespawnItem = true;
        }
    }

    #endregion

    #region SubtractItem

    public void RemoveAnEquipment(Equipment equipment) => equipments.Remove(equipment);

    public void DeductResource(Resource resource, int subtractAmount)
    {
        resource.stackCount -= subtractAmount; //Nếu có tồn tại resource cần remove thì sẽ trừ số lượng của nó đi

        //Nếu trừ xong mà số lượng vẫn về 0 hoặc thậm chí về âm thì sẽ xóa resource đó khỏi inventory luôn
        if (resource.stackCount <= 0) resourceList.Remove(resource);
    }

    #endregion
}


[Serializable]
public class Resource
{
    public Item itemProfile;
    public int stackCount;
}

[Serializable]
public class Equipment
{
    public Item itemProfile;

    public int level = 1;
}