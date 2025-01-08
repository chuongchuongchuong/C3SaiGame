using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChuongLibrary.GameDev;

public class CameraMovement : ChuongMonoSingleton<CameraMovement>
{
    private int _speed = 5;
    private Vector3 _targetPosition;

    private void Update()
    {
        GetTargerPosition();
        FollowTarget();
    }

    private void GetTargerPosition()
    {
        _targetPosition = playerMovement.Instance.transform.parent.position; // Get Player position
        _targetPosition.z = -10;
    }


    private void FollowTarget()
    {
        transform.parent.position = Vector3.Lerp(transform.parent.position, _targetPosition,
            _speed * Time.deltaTime);
    }
}