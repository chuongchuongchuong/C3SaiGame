using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkList : BaseListTransform
{
    #region Singleton Implementation
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
    #endregion
    
    public Transform GetRandomPrefab() => List[Random.Range(0, List.Count)];
}