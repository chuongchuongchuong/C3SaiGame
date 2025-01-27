using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentInfo : MonoBehaviour
{
    public Equipment equipment;

    private void OnEnable()
    {
        equipment = new();
    }

    private void Start() => OnEnable();
}