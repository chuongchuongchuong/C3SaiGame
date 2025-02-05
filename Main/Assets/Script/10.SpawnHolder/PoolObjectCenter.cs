using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class PoolObjectCenter : ChuongMono
{
    #region Singleton Implementation

    public static PoolObjectCenter Instance { get; private set; }

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

    public BulletPoolObject bullet;
    public JunkPoolObject junk;
    public DropItemPoolObject dropItem;
    public EnemyPoolObject enemy;
    public VFXPoolObject vfx;

    protected override void Reset_LoadComponents()
    {
        bullet = GetComponentInChildren<BulletPoolObject>();
        junk = GetComponentInChildren<JunkPoolObject>();
        dropItem = GetComponentInChildren<DropItemPoolObject>();
        enemy = GetComponentInChildren<EnemyPoolObject>();
        vfx = GetComponentInChildren<VFXPoolObject>();
    }
}