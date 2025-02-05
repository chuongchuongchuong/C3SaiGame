using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    public ItemName itemName = ItemName.NoItem;
    public Transform prefab;
    public ItemType itemType = ItemType.NoType;

    public List<Recipe> Uplevelrecipes;
    //public int defaultMaxStack = 7;
}


public enum ItemName
{
    NoItem,
    Sword,
    Axe,
    Key,
    BluePotion,
}

public enum ItemType
{
    NoType,
    Resource,
    Equipment,
}

[Serializable]
public class Recipe
{
    public List<Ingredient> ingredients;
}

[Serializable]
public class Ingredient
{
    public Item item;
    public int amount;
}