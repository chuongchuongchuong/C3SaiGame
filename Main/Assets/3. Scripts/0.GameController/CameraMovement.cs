using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : ChuongMono
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
        _targetPosition = PlayerCenter.Instance.transform.position; // Get Player position
        _targetPosition.z = -10;
    }


    private void FollowTarget()
    {
        transform.parent.position = Vector3.Lerp(transform.parent.position, _targetPosition,
            _speed * Time.deltaTime);
    }
}