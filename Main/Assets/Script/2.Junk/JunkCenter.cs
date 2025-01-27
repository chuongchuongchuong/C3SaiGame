using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCenter : ChuongMono
{
    #region Singleton Implementation
    
    public static JunkCenter Instance { get; private set; }
    
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
    
    public JunkList junkList;
    public JunkSpawner junkSpawner;

    protected override void Reset_LoadComponents()
    {
        junkList = GetComponentInChildren<JunkList>();
        junkSpawner = GetComponentInChildren<JunkSpawner>();
    }
}
