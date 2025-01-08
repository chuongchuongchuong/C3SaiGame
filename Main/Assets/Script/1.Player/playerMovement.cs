using System;
using ChuongLibrary.GameDev;
using UnityEngine;
using UnityEngine.Animations;

public class playerMovement : ChuongMonoSingleton<playerMovement>
{
    private int _speed;
    private Vector3 _targetPosition;

    protected override void ResetValues_Awake()
    {
        var shipData = Resources.Load<ShipData>("ScriptableObject/MainShip"); // Get the speed value in data
        _speed = shipData.moveSpeed;
    }

    private void Update()
    {
        GetTargerPosition();
        Game2D.LookAtTarget(transform.parent, _targetPosition);
        FollowTarget();

        
    }

    private void GetTargerPosition()
    {
        _targetPosition = InputManager.Instance.mouseWorldPos; // Get the mouse position
    }
    

    private void FollowTarget()
    {
        transform.parent.position = Vector3.Lerp(transform.parent.position, _targetPosition,
            _speed * Time.deltaTime);
    }
}