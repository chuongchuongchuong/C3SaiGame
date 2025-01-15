using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looter : ChuongMono
{
    public Inventory inventory;

    protected override void LoadComponents_Reset()
    {
        inventory = transform.parent.GetComponentInChildren<Inventory>();
    }

    public void Loot(PickableItem pickableItem)
    {
        inventory.AddItem(pickableItem.itemName, 1);
        Debug.Log(pickableItem.itemName);

        pickableItem.despawner.Despawn();
    }
}