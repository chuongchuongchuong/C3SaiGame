using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkFly : BaseFlyStraight
{
    [SerializeField] private float rotationSpeed = 10;
    [SerializeField] private Transform model;

    protected override void ResetValues_Awake()
    {
        speed = 2f;
        direction = Vector2.right;
    }

    protected override void LoadObjects_ResetInPrefab()
    {
        model = transform.parent.Find("Sprite");
    }


    private void FixedUpdate()
    {
        model.Rotate(rotationSpeed * Time.fixedDeltaTime * new Vector3(0, 0, 10));
    }
}