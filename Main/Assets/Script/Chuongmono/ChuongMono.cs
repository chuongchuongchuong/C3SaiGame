using System;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public abstract class ChuongMono : MonoBehaviour
{
    protected virtual void Reset()
    {
        GuaranteeSingleton();
        Reset_LoadObjects();
        Reset_LoadComponents();
    }

    protected virtual void Awake()
    {
        GuaranteeSingleton();
        Awake_ResetValues();
    }

    protected virtual void Start()
    {
        Start_DisableUIObjects();
    }
    
    
    // @formatter:off
    protected virtual void GuaranteeSingleton(){}//Dành cho ChuongMonoSingleton override vào
    protected virtual void Reset_LoadComponents(){}// Chuyên để load Component
    protected virtual void Reset_LoadObjects(){}//Load các loại Object: GameObject, Prefabs,...
    protected virtual void Awake_ResetValues(){}// lấy giá trị biến trong Scriptable Data, reset lại biến
    protected virtual void Start_DisableUIObjects(){}// SetActive(false) những UI cuối scene
    // @formatter:on

    //Reset_LoadObjects() (Datatype): GameObject, Transform, Prefab, cho vào danh sách Transform, ...
    //Reset_LoadComponents()(Datatype): Các loại Component, cả Mono, ...
    //Awake_ResetValues() (Datatype): Reset lại giá trị của các biến nguyên thủy như int, float, ...
}