using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Looter : ChuongMono
{
    public PlayerCenter playerCenter;
    public bool canDespawnItem;
    private Item lootItem;

    [SerializeField] protected List<Item> profiles;

    protected override void Reset_LoadComponents()
    {
        playerCenter = transform.parent.GetComponent<PlayerCenter>();
    }

    protected override void Reset_LoadObjects()
    {
        profiles = new List<Item>(Resources.LoadAll<Item>(StringKeeper.ItemPathFolder));
        lootItem = ScriptableObject.CreateInstance<Item>();
    }

    public void Loot(PickableItem pickableItem)
    {
        var itemNameString = pickableItem.transform.parent.name.Replace("(Clone)", "").Trim();
        //Debug.Log(itemNameString);
        if (!System.Enum.TryParse(itemNameString, out ItemName itemName)) return;

        if (!IsTheItemExists(itemName)) return;

        if (lootItem.itemType == ItemType.Equipment) playerCenter.inventory.AddAnEquipment(lootItem);
        else if (lootItem.itemType == ItemType.Resource) playerCenter.inventory.AddResource(lootItem, 1);
        else return;

        //Debug.Log(canDespawnItem);
        if (!canDespawnItem) return;
        pickableItem.despawner.Despawn();
        canDespawnItem = false;
    }

    private bool IsTheItemExists(ItemName itemName)
    {
        lootItem = profiles.Find((itemCheck) => itemCheck.itemName == itemName);
        return lootItem != null;
    }
}