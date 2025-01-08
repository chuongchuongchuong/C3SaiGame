using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    public BaseHealth health;

    void Awake()
    {
        health = transform.parent.GetComponentInChildren<BaseHealth>();
    }
}