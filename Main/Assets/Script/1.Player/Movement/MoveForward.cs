using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : ChuongMono
{
    private float normalSpeed;
    [SerializeField] private float speed;
    [SerializeField] private Transform forwardObj;

    protected override void Awake_ResetValues()
    {
        normalSpeed = 5;
        speed = normalSpeed;
        forwardObj = transform.GetChild(0);
    }

    private void Update() => moveForward();

    // @formatter:off
    private void moveForward()
    {
        if (Vector2.Distance(transform.parent.position, InputManager.Instance.mouseWorldPos) < .1f) return;
        speed = (Vector2.Distance(transform.parent.position, InputManager.Instance.mouseWorldPos) < 1f) ?
            0.1f : normalSpeed;

        transform.parent.position = Vector3.MoveTowards(transform.parent.position, forwardObj.position,
            speed * Time.deltaTime);
    }
    // @formatter:on
}