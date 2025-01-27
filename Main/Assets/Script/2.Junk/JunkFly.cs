using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkFly : BaseFlyStraight
{
    [SerializeField] private float rotationSpeed = 10;
    [SerializeField] private Transform model;

    protected override void Awake_ResetValues()
    {
        speed = 2f;
        direction = Vector2.right;
    }

    protected override void Reset_LoadObjects()
    {
        model = transform.parent.GetChild(0);
    }


    private void FixedUpdate()
    {
        model.Rotate(rotationSpeed * Time.fixedDeltaTime * new Vector3(0, 0, 10));
    }
}