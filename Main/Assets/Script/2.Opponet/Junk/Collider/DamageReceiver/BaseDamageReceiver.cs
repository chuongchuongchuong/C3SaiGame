using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDamageReceiver : MonoBehaviour
{
    public BaseHealth health;

    private void Awake()
    {
        health = transform.parent.GetComponentInChildren<BaseHealth>();
    }
}
