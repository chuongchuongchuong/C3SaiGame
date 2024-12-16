using System;
using UnityEngine;

public abstract class ChuongMonoWithoutSingleton : MonoBehaviour
{
    protected virtual void Reset()
    {
        LoadObjects();
        LoadComponent();
    }

    protected virtual void Awake()
    {
        GetScriptableDataValue();
    }
    
    
    // @formatter:off
    protected virtual void LoadComponent(){}// Chuyên để load Component
    protected virtual void LoadObjects(){}//Load các loại Object: GameObject, Prefabs,...
    protected virtual void GetScriptableDataValue(){}// lấy giá trị biến trong Scriptable Data
    
    // @formatter:on
}