using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "DropItem")]
public class DropItemData: ScriptableObject
{
    public List<DropItemDataStruct> ItemDataList;
}


[System.Serializable]
public struct DropItemDataStruct
{
    public GameObject prefab;
    public int dropRate;
}

