using System;
using UnityEngine;
using System.Collections.Generic;

public class BulletsList : BaseListTransform
{
    #region Singleton Implementation

    public static BulletsList Instance { get; private set; }

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

    /*protected override void UpdateIndex()
    {
        if (InputManager.Instance.ChangeToBullet_1Button()) index = 1;
        if (InputManager.Instance.ChangeToBullet_2Button()) index = 2;
    }*/
}