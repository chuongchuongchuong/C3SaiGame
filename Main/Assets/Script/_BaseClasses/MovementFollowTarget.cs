using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChuongLibrary.GameDev;

public abstract class MovementFollowTarget : ChuongMono
{
    protected float _speed;
    protected Vector3 _targetPosition;

    protected virtual void Update() => Movement();
    protected virtual void Movement()
    {
        DetermineTargetPosition();
        FollowTarget();
    }

    protected abstract void GetTargetPosition();

    protected virtual void FollowTarget()
    {
        transform.parent.position = Vector3.Lerp(transform.parent.position, _targetPosition,
            _speed * Time.deltaTime);
    }

    protected virtual void DetermineTargetPosition()
    {
        GetTargetPosition();
        Game2D.LookAtTarget(transform.parent, _targetPosition);
    }
    
}
