using System;
using ChuongLibrary.GameDev;
using UnityEngine;
using UnityEngine.Animations;

public class ScriptMovement : ChuongMonoSingleton<ScriptMovement>
{
    private int _speed;
    private Vector3 _targetPosition;

    protected override void ResetValues()
    {
        var shipData = Resources.Load<ShipData>("MainShip"); // Get the speed value in data
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
        _targetPosition = ScriptInputManager.Instance.mouseWorldPos; // Get the mouse position
    }
    

    private void FollowTarget()
    {
        transform.parent.position = Vector3.Lerp(transform.parent.position, ScriptInputManager.Instance.mouseWorldPos,
            _speed * Time.deltaTime);
    }
}