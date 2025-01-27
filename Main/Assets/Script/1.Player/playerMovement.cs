using System;
using ChuongLibrary.GameDev;
using UnityEngine;
using UnityEngine.Animations;

public class playerMovement : MovementFollowTarget
{
    protected override void Awake_ResetValues()
    {
        var shipData = Resources.Load<ShipData>(StringKeeper.MainShipDataPath); // Get the speed value in data
        _speed = shipData.moveSpeed;
    }
    
    protected override void GetTargetPosition()
    {
        _targetPosition = InputManager.Instance.mouseWorldPos; // Get the mouse position
    }
    
}