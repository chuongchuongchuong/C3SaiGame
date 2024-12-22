using System;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public abstract class ChuongMono : MonoBehaviour
{
    protected virtual void Reset()
    {
        LoadObjects();
        LoadComponents();
    }

    protected virtual void Awake()
    {
        GuaranteeSingleton();
        ResetValues();
    }
    
    protected virtual void Start()
    {
        DisableUIObjects();
    }
    
    
    // @formatter:off
    protected virtual void GuaranteeSingleton(){}//Dành cho ChuongMonoSingleton override vào
    protected virtual void LoadComponents(){}// Chuyên để load Component
    protected virtual void LoadObjects(){}//Load các loại Object: GameObject, Prefabs,...
    protected virtual void ResetValues(){}// lấy giá trị biến trong Scriptable Data, reset lại biến
    protected virtual void DisableUIObjects(){}// SetActive(false) những UI cuối scene
    // @formatter:on
}