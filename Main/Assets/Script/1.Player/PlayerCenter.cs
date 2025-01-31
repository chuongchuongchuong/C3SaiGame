using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCenter : ChuongMono
{
    #region Singleton Implementation

    public static PlayerCenter Instance { get; private set; }

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

    public playerMovement playerMovement;
    public Looter looter;
    public PlayerShooting playerShooting;
    public BulletsList bulletsList;
    public PlayerHealth playerHealth;
    public Inventory inventory;

    protected override void Reset_LoadComponents()
    {
        playerMovement = GetComponentInChildren<playerMovement>();
        looter = GetComponentInChildren<Looter>();
        playerShooting = GetComponentInChildren<PlayerShooting>();
        bulletsList = GetComponentInChildren<BulletsList>();
        playerHealth = GetComponentInChildren<PlayerHealth>();
        inventory = GetComponentInChildren<Inventory>();
    }
}