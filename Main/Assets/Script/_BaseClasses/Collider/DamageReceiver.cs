using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    public BaseHealth health;

    private void Reset()
    {
        health = transform.parent.GetComponentInChildren<BaseHealth>();
    }
}