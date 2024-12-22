using System;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public abstract class ChuongPrefabs : MonoBehaviour
{
    protected virtual void Awake()
    {
        ResetValues();
        LoadObjects();
        LoadComponents();
    }
    
    // @formatter:off
    protected virtual void OnEnable() {}
    // @formatter:on
    protected virtual void Start()
    {
        DisableUIObjects();
        OnEnable();
    }
    
    
    // @formatter:off
    protected virtual void LoadComponents(){}// Chuyên để load Component
    protected virtual void LoadObjects(){}//Load các loại Object: GameObject, Prefabs,...
    protected virtual void ResetValues(){}// lấy giá trị biến trong Scriptable Data, reset lại biến
    protected virtual void DisableUIObjects(){}// SetActive(false) những UI cuối scene
    // @formatter:on
}