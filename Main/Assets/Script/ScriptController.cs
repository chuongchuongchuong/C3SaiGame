using System;
using UnityEngine;

public class ScriptController : MonoBehaviour
{
    private int _speed;
    private Vector3 _mouseWorldPos;

    private void Awake()
    {
        var shipData = Resources.Load<ShipData>("MainShip");
        _speed = shipData.speed;
    }

    private void Update()
    {
        GetMousePosition();
        FollowMouse();
    }

    private void GetMousePosition()
    {
        _mouseWorldPos = ScriptInputManager.Instance.mouseWorldPos;
    }

    private void FollowMouse()
    {
        transform.parent.position = Vector3.Lerp(transform.parent.position, ScriptInputManager.Instance.mouseWorldPos,
            _speed * Time.deltaTime);
    }
}