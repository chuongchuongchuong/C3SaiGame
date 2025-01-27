using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentUplevel : ChuongMono
{
    [SerializeField] private Inventory inventory;
    private Recipe currentLevelRecipe;

    protected override void Reset_LoadComponents()
    {
        inventory = transform.parent.GetComponent<Inventory>();
    }

    [ContextMenu("LevelUp")]
    public void Uplevel() => UpgradeEquipment(inventory.equipments[0]);

    private void UpgradeEquipment(Equipment equipment)
    {
        if (!CanUpgrade(equipment)) return;
        UpgradeLevel(equipment);
    }
    
    #region CanUpgrade

    private bool CanUpgrade(Equipment equipment)
    {
        //Nếu tham số truyền vào (equipment) không nằm trong danh sách equipment hiện đang có trên người thì sai luôn
        if (!inventory.equipments.Contains(equipment))
        {
            Debug.Log("tham số truyền vào (equipment) không nằm trong danh sách equipment");
            return false;
        }

        //Nếu đồ muốn nâng cấp đấy đã đạt level max thì cũng ko nâng cấp đc
        if (equipment.level == equipment.itemProfile.Uplevelrecipes.Count + 1) return false;
        //Debug.Log(equipment.level+"   "+equipment.itemProfile.Uplevelrecipes.Count);

        //currentLevelRecipe là cái công thức lên level hiện tại của đồ đó
        currentLevelRecipe = equipment.itemProfile.Uplevelrecipes[equipment.level - 1];
        //Debug.Log(currentLevelRecipe.ingredients.Count);

        return AllResourcesEnough();
    }

    private bool AllResourcesEnough()
    {
        //với mỗi cái ingredient trong công thức này
        foreach (var ingredient in currentLevelRecipe.ingredients)
        {
            if (!OneResourceEnough(ingredient)) return false; //chỉ cần 1 tài nguyên ko đủ thì false luôn
        }

        //Khi đã đủ tài nguyên cũng như số lượng của nó thì sẽ đủ điều kiện up level cho đồ đó
        return true;
    }

    private bool OneResourceEnough(Ingredient ingredient)
    {
        foreach (var resource in inventory.resourceList)
        {
            //Debug.Log("flag");
            //kiểm tra xem là có tài nguyên này trùng với tài nguyên yêu cầu không?
            if (resource.itemProfile != ingredient.item) continue;

            if (resource.stackCount >= ingredient.amount) return true;
            else Debug.Log("ingredient.item.itemName"+" ko đủ");
            return false;
        }

        Debug.Log(ingredient.item.itemName+" Ko có trong resourceList");
        return false;
    }

    
    #endregion

    #region UpgradeLevel
    
    private void UpgradeLevel(Equipment equipment)
    {
        equipment.level++; //lên level
        DeductResource(); // trừ các tài nguyên liên quan
    }
    private void DeductResource()
    {
        foreach (var ingredient in currentLevelRecipe.ingredients)
        {
            var resource = inventory.resourceList.Find((_resource) => _resource.itemProfile == ingredient.item);
            inventory.DeductResource(resource, ingredient.amount);
        }
        
    }
    
    #endregion
}