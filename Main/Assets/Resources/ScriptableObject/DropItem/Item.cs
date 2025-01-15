using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    public ItemName itemName = ItemName.NoItem;
    public GameObject prefab;
    public ItemType itemType = ItemType.NoType;
    //public int defaultMaxStack = 7;
}


public enum ItemName
{
    NoItem,
    Sword,
    Axe,
    Key,
}

public enum ItemType
{
    NoType,
    Resource,
    Equipment,
}