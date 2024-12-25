using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkFly : BaseFlyStraight
{
    [SerializeField] private float rotationSpeed = 10;
    private Transform model;

    protected override void Awake_ResetValues()
    {
        speed = 1f;
        direction = Vector2.right;
    }

    protected override void Awake_LoadObjects()
    {
        model = transform.parent.Find("Sprite");
    }


    private void FixedUpdate()
    {
        model.Rotate(rotationSpeed * Time.fixedDeltaTime * new Vector3(0, 0, 10));
    }
}