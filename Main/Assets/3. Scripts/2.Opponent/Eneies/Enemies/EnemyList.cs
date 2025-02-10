using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyList : BaseListTransform
{
    #region Singleton Implementation
    public static EnemyList Instance { get; private set; }

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
