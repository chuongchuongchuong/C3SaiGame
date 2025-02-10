using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMoveForward : ChuongMono
{
    [SerializeField] private float normalSpeed;
    [SerializeField] private float downSpeed;
    
    private float speed;
    [SerializeField] private Transform forwardObj;
    

    protected override void Reset_LoadObjects() => forwardObj = transform.GetChild(0);
    protected override void Awake_ResetValues()
    {
        downSpeed = 0.1f;
        normalSpeed = 5;
    }

    private void Update() => moveForward();

    // @formatter:off
    private void moveForward()
    {
        if (Vector2.Distance(transform.parent.position, InputManager.Instance.mouseWorldPos) < .1f) return;
        speed = (Vector2.Distance(transform.parent.position, InputManager.Instance.mouseWorldPos) < 1f) ?
            downSpeed : normalSpeed;

        transform.parent.position = Vector3.MoveTowards(transform.parent.position, forwardObj.position,
            speed * Time.deltaTime);
    }
    // @formatter:on
}