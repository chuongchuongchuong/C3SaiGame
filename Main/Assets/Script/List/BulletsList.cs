using System;
using UnityEngine;
using System.Collections.Generic;

public class BulletsList : ChuongMonoSingleton<BulletsList>
{
    public List<Transform> weaponList;
    public int weaponIndex = 1;
    public Transform weaponPrefab;


    protected override void LoadObjects()
    {
        //Load weaponList
        foreach (Transform child in transform)
        {
            weaponList.Add(child);
        }


        GetWeaponByIndex(weaponIndex);
    }

    //Get the weaponPrefab
    public void GetWeaponByIndex(int index) => weaponPrefab = weaponList[weaponIndex - 1];

    private void FixedUpdate()
    {
        weaponIndex = ScriptInputManager.Instance.weaponIndex;
        GetWeaponByIndex(weaponIndex);
    }
}