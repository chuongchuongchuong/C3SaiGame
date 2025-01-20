using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looter : ChuongMono
{
    public Inventory inventory;
    public bool canDespawnItem;

    protected override void LoadComponents_Reset()
    {
        inventory = transform.parent.GetComponentInChildren<Inventory>();
    }

    public void Loot(PickableItem pickableItem)
    {
        var itemNameString = pickableItem.transform.parent.name.Replace("(Clone)", "").Trim();
        Debug.Log(itemNameString);
        if (!System.Enum.TryParse(itemNameString, out ItemName itemName)) return;
        
        inventory.AddItem(itemName, 1);

        //Debug.Log(canDespawnItem);
        if (!canDespawnItem) return;
        pickableItem.despawner.Despawn();
        canDespawnItem = false;
    }
}