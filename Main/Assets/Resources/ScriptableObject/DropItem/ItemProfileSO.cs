using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemProfileSO")]
public class ItemProfileSO : ScriptableObject
{
    public ItemCode itemCode = ItemCode.NoItem;
    public ItemType itemType = ItemType.NoType;
    public string itemName;
    public int defaultMaxStack = 7;
}


public enum ItemCode
{
    NoItem = 0,
    Item1 = 1,
    Item2 = 2,
}

public enum ItemType
{
    NoType = 0,
    Resource = 1,
    Equipment = 2,
}