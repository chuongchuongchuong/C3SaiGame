using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Looter : ChuongMono
{
    #region Get Object Center

    public PlayerCenter playerCenter;
    protected override void LoadObjectCenter() => playerCenter ??= transform.parent.GetComponent<PlayerCenter>();

    #endregion

    [SerializeField] protected List<Item> profiles;

    public bool canDespawnItem;
    private Item lootItem;
    public PickableItem pickableItem;


    protected override void Reset_LoadObjects()
    {
        profiles = new List<Item>(Resources.LoadAll<Item>(StringKeeper.ItemPathFolder));
        lootItem = ScriptableObject.CreateInstance<Item>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CanLoot(other)) Loot(pickableItem);
    }

    protected virtual bool CanLoot(Collider2D hitInfo)
    {
        pickableItem = hitInfo.GetComponent<PickableItem>();
        if (pickableItem == null) return false;

        return true;
    }

    public void Loot(PickableItem pickableItem)
    {
        var itemNameString = pickableItem.transform.parent.name.Replace("(Clone)", "").Trim();
        //Debug.Log(itemNameString);
        if (!System.Enum.TryParse(itemNameString, out ItemName itemName)) return;

        if (!IsTheItemExists(itemName)) return;

        if (lootItem.itemType == ItemType.Equipment)
            playerCenter.inventory.AddAnEquipment(lootItem);
        else if (lootItem.itemType == ItemType.Resource)
            playerCenter.inventory.AddResource(lootItem, 1);
        else return;
        
        pickableItem.equipmentCenter.despawner.IsLooted = true;
    }

    private bool IsTheItemExists(ItemName itemName)
    {
        lootItem = profiles.Find((itemCheck) => itemCheck.itemName == itemName);
        return lootItem != null;
    }
}