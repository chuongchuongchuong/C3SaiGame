using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : ChuongMono
{
    [SerializeField] protected int equipMaxSlot = 6;
    [SerializeField] protected int resourceMaxSlot = 7;
    [SerializeField] protected Looter looter;
    
    [SerializeField] protected List<Item> profiles;

    [Header("Equipment")]
    [SerializeField] protected List<Item> equipments;
     protected Item pickedItem;

    [Header("Resources")]
    [SerializeField] protected List<Resource> resourceList;
     protected Resource resource;

    

    protected override void LoadComponents_Reset()
    {
        looter = transform.parent.GetComponentInChildren<Looter>();
        pickedItem = Resources.Load<Item>("Items/" + pickedItem.name);
    }

    protected override void LoadObjects_Reset()
    {
        profiles = new List<Item>(Resources.LoadAll<Item>(StringKeeper.ItemPathFolder));
    }

    //[ContextMenu("Add Item")]
    //protected void Add() => AddItem(ItemName.Sword, 3);


    public void AddItem(ItemName itemName, int addAmount = 1)
    {
        if (!IsTheItemExists(itemName)) return; // Kiểm tra xem item này có tồn tại ko

        if (pickedItem.itemType == ItemType.Equipment)
            AddAnEquipment(); //Nếu item này là equipment thì thêm vào equipment
        else AddResource(addAmount); // Nếu item này là resource thì thêm vào theo cơ chế của resource
    }

    private bool IsTheItemExists(ItemName itemName)
    {
        pickedItem = profiles.Find((item) => item.itemName == itemName);
        if (pickedItem == null)
        {
            Debug.Log("picked item not Found:" + itemName);
            return false;
        }

        return true;
    }
    private void AddAnEquipment()
    {
        if (equipments.Count == equipMaxSlot) return; //Nhiều nhất là 6 slot đồ
        if (IsPickedTheSameEquipment()) return; //Nếu đồ này bị trùng thì sẽ ko add thêm nữa

        equipments.Add(pickedItem); // Add thêm đồ vào equipments
        looter.canDespawnItem = true;
        return;

        bool IsPickedTheSameEquipment()
        {
            var theSameEquipment = equipments.Find((item) => item == pickedItem);
            return theSameEquipment != null;
        }
    }
    private void AddResource(int addAmount)
    {
        if (PickTheSameResource()) StackDeResourceIntoResourceList(addAmount);
        else AddNewResourceSlot(addAmount);
        return;

        bool PickTheSameResource()
        {
            resource = resourceList.Find((resource) => resource.itemProfile == pickedItem);
            return resource != null;
        }

        void StackDeResourceIntoResourceList(int addAmount)
        {
            resource.stackCount += addAmount;
            looter.canDespawnItem = true;
        }

        void AddNewResourceSlot(int addAmount)
        {
            if (resourceList.Count == resourceMaxSlot) return; // nếu maxslot đã full thì ko thể thêm được nữa

            var newResource = new Resource
            {
                itemProfile = pickedItem,
                stackCount = addAmount
            };

            resourceList.Add(newResource);
            Debug.Log("picked " + pickedItem.itemName);
            looter.canDespawnItem = true;
        }
    }
}


[Serializable]
public class Resource
{
    public Item itemProfile;
    public int stackCount;
}