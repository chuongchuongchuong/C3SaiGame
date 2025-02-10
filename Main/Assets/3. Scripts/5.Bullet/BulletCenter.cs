using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCenter : ChuongMono
{
    #region Singleton Implementation

    public static BulletCenter Instance { get; private set; }

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

    public BulletsList List;

    protected override void Reset_LoadComponents()
    {
        List = GetComponentInChildren<BulletsList>();
    }
}