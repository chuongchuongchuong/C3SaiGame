using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : ChuongMono
{
    [SerializeField] protected int maxSlot = 70;
    [SerializeField] protected List<LootSlot> LootList;


    [ContextMenu("Add Item")]
    protected void Add() => AddItem(ItemName.Sword, 3);


    public void AddItem(ItemName itemName, int addAmount = 1)
    {
        var pickedItem = LootList.Find((item) => item.ItemProfile.itemName == itemName);
        if (IsPickTheSameItem(pickedItem))
            StackthatItemintoLootList(pickedItem, addAmount);
        AddNewItemintoLootList(itemName, addAmount);
    }

    protected bool IsPickTheSameItem(LootSlot pickedItem) => pickedItem != null;

    protected void StackthatItemintoLootList(LootSlot pickedItem, int addAmount = 1)
    {
        if (pickedItem.stackCount == pickedItem.maxStack) return;
        var newCount = pickedItem.stackCount + addAmount;
        if (newCount > pickedItem.maxStack) newCount = pickedItem.maxStack;
        pickedItem.stackCount = newCount;
    }

    protected void AddNewItemintoLootList(ItemName itemName, int addAmount = 1)
    {
        var profiles = Resources.LoadAll<Item>(StringKeeper.ItemPathFolder);
        foreach (var profile in profiles)
        {
            if (profile.itemName != itemName) continue;
            var newLootITem = new LootSlot
            {
                ItemProfile = profile,
                //maxStack = profile.defaultMaxStack
                stackCount = addAmount
            };
            newLootITem.GetDaMaxStack();
            
            LootList.Add(newLootITem);
            return;
        }

        Debug.Log("New picked item not Found:" + itemName);
    }
}

public class LootSlot
{
    public Item ItemProfile;
    public int stackCount;
    public int maxStack;

    public void GetDaMaxStack()
    {
        switch (ItemProfile.itemName)
        {
            case ItemName.Axe :
                maxStack = 7;
                break;
            case ItemName.Sword:
                maxStack = 6;
                break;
            case ItemName.Key:
                maxStack = 4;
                break;
        }
    }
}