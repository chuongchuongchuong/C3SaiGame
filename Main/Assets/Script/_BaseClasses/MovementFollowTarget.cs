using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChuongLibrary.Game2D;

public abstract class MovementFollowTarget : ChuongMono
{
    protected float _speed;
    protected Vector3 _targetPosition;

    protected virtual void Update()
    {
        _targetPosition = GetTargetPosition();
        Movement();
    }

    protected virtual void Movement()
    {
        RotateShip();
        FollowTarget();
    }

    protected abstract Vector3 GetTargetPosition();

    protected virtual void FollowTarget()
    {
        transform.parent.position = Vector3.Lerp(transform.parent.position, _targetPosition,
            _speed * Time.deltaTime);
    }

    protected virtual void RotateShip()
    {
        LookAtTargetClass.LookAtTarget(transform.parent, _targetPosition, "");
    }
}