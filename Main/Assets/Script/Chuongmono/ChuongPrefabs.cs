using System;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public abstract class ChuongPrefabs : MonoBehaviour
{
    protected void Reset()
    {
        LoadObjects_ResetInPrefab();
        LoadComponents_ResetInPrefab();
    }

    protected virtual void Awake()
    {
        LoadObjectsOutsidePrefab_Awake();
        LoadComponentsOutsidePrefab_Awake();
        ResetValues_Awake();
    }

    protected virtual void OnEnable()
    {
        return;
    }

    protected virtual void Start()
    {
        Start_DisableUIObjects();
        OnEnable();
    }
    
    
    // @formatter:off
    protected virtual void LoadComponents_ResetInPrefab(){}
    protected virtual void LoadObjects_ResetInPrefab(){}
    protected virtual void LoadComponentsOutsidePrefab_Awake(){}
    protected virtual void LoadObjectsOutsidePrefab_Awake(){}
    protected virtual void ResetValues_Awake(){}
    protected virtual void Start_DisableUIObjects(){}
    // @formatter:on

    //LoadObjects() (Datatype): GameObject, Transform, Prefab, List<Transform>, ...
    //LoadComponents()(Datatype): Các loại Component, Monobihaviour, ...
    //ResetValues() (Datatype): Reset lại giá trị của các biến nguyên thủy như int, float, ...
    //DisableUIObjects() (Datatype): Tắt các UI chính của game
}