using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChuongLibrary.Game2D;

public abstract class MovementFollowTarget : ChuongMono
{
    [SerializeField] protected float _speed;
    protected Vector3 _targetPosition;

    protected virtual void Update() => FollowTarget();
    
    protected virtual void FollowTarget()
    {
        transform.parent.position = Vector3.Lerp(transform.parent.position, GetTargetPosition(),
            _speed * Time.deltaTime);
    }

    protected abstract Vector3 GetTargetPosition();
}