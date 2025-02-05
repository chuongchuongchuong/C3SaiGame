using UnityEngine;

public abstract class ChuongMono : MonoBehaviour
{
    protected virtual void Reset()
    {
        GuaranteeSingleton();
        LoadObjectCenter();
        Reset_LoadObjects();
        Reset_LoadComponents();
    }

    protected virtual void Awake()
    {
        GuaranteeSingleton();
        LoadObjectCenter();
        Awake_ResetValues();
        Awake_Others();
    }

    protected virtual void Start()
    {
        DisableUIObjects_Start();
    }
    
    
    // @formatter:off
    protected virtual void GuaranteeSingleton(){}
    protected virtual void LoadObjectCenter(){}
    protected virtual void Reset_LoadComponents(){}
    protected virtual void Reset_LoadObjects(){}
    protected virtual void Awake_ResetValues(){}
    protected virtual void Awake_Others(){}
    protected virtual void DisableUIObjects_Start(){}
    // @formatter:on

    /*LoadObjects() (Datatype): GameObject, Transform, Prefab, List<Transform>, ...
    LoadComponents()(Datatype): Các loại Component, Monobihaviour, ...
    ResetValues() (Datatype): Reset lại giá trị của các biến nguyên thủy như int, float, ...
    Others(): làm những nhiệm vụ khác
    DisableUIObjects(): Tắt các UI chính của game*/
}