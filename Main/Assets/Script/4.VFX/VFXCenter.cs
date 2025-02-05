using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXCenter : ChuongMono
{
    #region Singleton Implementation

    public static VFXCenter Instance { get; private set; }

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

    public VFXSpawner spawner;

    protected override void Awake_ResetValues()
    {
        spawner = GetComponentInChildren<VFXSpawner>();
    }
}