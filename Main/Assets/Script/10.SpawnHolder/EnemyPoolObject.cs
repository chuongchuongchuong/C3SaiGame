using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolObject : BasePoolPattern
{
    #region Singleton Implementation

    public static EnemyPoolObject Instance { get; private set; }

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
}
