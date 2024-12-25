using System;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public abstract class ChuongPrefabs : MonoBehaviour
{
    protected virtual void Awake()
    {
        Awake_LoadObjects();
        Awake_LoadComponents();
        Awake_ResetValues();
    }
    
    // @formatter:off
    protected virtual void OnEnable() {}
    // @formatter:on
    protected virtual void Start()
    {
        Start_DisableUIObjects();
        OnEnable();
    }
    
    
    // @formatter:off
    protected virtual void Awake_LoadComponents(){}// Chuyên để load Component
    protected virtual void Awake_LoadObjects(){}//Load các loại Object: GameObject, Prefabs,...
    protected virtual void Awake_ResetValues(){}// lấy giá trị biến trong Scriptable Data, reset lại biến
    protected virtual void Start_DisableUIObjects(){}// SetActive(false) những UI cuối scene
    // @formatter:on
    
    //Awake_LoadObjects() (Datatype): GameObject, Transform, Prefab, cho vào danh sách Transform, ...
    //Awake_LoadComponents()(Datatype): Các loại Component, cả Mono, ...
    //Awake_ResetValues() (Datatype): Reset lại giá trị của các biến nguyên thủy như int, float, ...
}