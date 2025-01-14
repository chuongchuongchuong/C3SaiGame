using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkList : BaseListTransform
{
    public static JunkList Instance { get; private set; }

    protected override void GuaranteeSingleton()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning("More than one " + GetType().Name + " in scene.");
            return;
        }

        Instance = this;
    }
    
    public void GetRandomPrefab() => GetPrefabByIndex(Random.Range(1, List.Count + 1));
}