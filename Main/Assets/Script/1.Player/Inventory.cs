using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : ChuongMono
{
    [SerializeField] protected int maxSlot = 70;
    [SerializeField] protected List<ItemInventoryStruct> Items;


    [ContextMenu("Add Item")]
    protected bool AddItem(ItemCode code, int addCount)
    {
        var item = GetItembyCode(code);
        var newCount = item.itemCount + addCount;
        if (newCount > item.maxStack) return false;
        item.itemCount = newCount;
        return true;
    }

    public virtual ItemInventoryStruct GetItembyCode(ItemCode code)
    {
        var item = Items.Find((item) => item.ItemProfile.itemCode == code);
        if (item == null) item = AddEmptyProfile(code);
        return item;
    }

    public virtual ItemInventoryStruct AddEmptyProfile(ItemCode code)
    {
        var profiles = Resources.LoadAll<ItemProfileSO>("Itempprofiles");
    }
}



public class ItemInventoryStruct
{
    public ItemProfileSO ItemProfile;
    public int itemCount;
    public int maxStack = 7;
}