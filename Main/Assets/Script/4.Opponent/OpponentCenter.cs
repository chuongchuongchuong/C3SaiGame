using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentCenter : ChuongMono
{
    #region Singleton Implementation

    public static OpponentCenter Instance { get; private set; }

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

    public EnemyList enemyList;
    public EnemySpawner enemySpawner;

    protected override void Reset_LoadComponents()
    {
        enemyList = GetComponentInChildren<EnemyList>();
        enemySpawner = GetComponentInChildren<EnemySpawner>();
    }
}