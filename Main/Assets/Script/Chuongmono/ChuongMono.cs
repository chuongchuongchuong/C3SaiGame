using System;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public abstract class ChuongMono : MonoBehaviour
{
    protected virtual void Reset()
    {
        GuaranteeSingleton();
        LoadObjects_Reset();
        LoadComponents_Reset();
    }

    protected virtual void Awake()
    {
        GuaranteeSingleton();
        ResetValues_Awake();
    }

    protected virtual void Start()
    {
        DisableUIObjects_Start();
    }
    
    
    // @formatter:off
    protected virtual void GuaranteeSingleton(){}
    protected virtual void LoadComponents_Reset(){}
    protected virtual void LoadObjects_Reset(){}
    protected virtual void ResetValues_Awake(){}
    protected virtual void DisableUIObjects_Start(){}
    // @formatter:on

    //LoadObjects() (Datatype): GameObject, Transform, Prefab, List<Transform>, ...
    //LoadComponents()(Datatype): Các loại Component, Monobihaviour, ...
    //ResetValues() (Datatype): Reset lại giá trị của các biến nguyên thủy như int, float, ...
    //DisableUIObjects() (Datatype): Tắt các UI chính của game
}