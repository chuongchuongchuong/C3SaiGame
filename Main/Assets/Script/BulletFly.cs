using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    private float bulletSpeed = 2;

    private void Awake()
    {
        bulletSpeed=Resources.Load<ShipData>("MainShip").bulletSpeed;
    }

    private void Update()
    {
        transform.parent.Translate(bulletSpeed * Time.deltaTime * Vector3.right);
    }
}