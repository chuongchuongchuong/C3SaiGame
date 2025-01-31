using System;
using UnityEngine;
using UnityEngine.Animations;

public class playerMovement : MovementFollowTarget
{
    private float rotSpeed;

    protected override void Awake_ResetValues()
    {
        var shipData = Resources.Load<ShipData>(StringKeeper.MainShipDataPath); // Get the speed value in data
        _speed = shipData.moveSpeed;
        rotSpeed = shipData.rotSpeed;
    }

    protected override Vector3 GetTargetPosition() => InputManager.Instance.mouseWorldPos; // Get the mouse position

    protected override void RotateShip()
    {
        ChuongLibrary.Game2D.LookAtTargetClass.GraduallyLookAtTarget(transform.parent, rotSpeed, _targetPosition);
    }
}