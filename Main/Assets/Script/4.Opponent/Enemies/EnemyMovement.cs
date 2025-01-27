using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MovementFollowTarget
{
    [SerializeField] private float minDistance;

    protected override void Awake_ResetValues()
    {
        /*var shipData = Resources.Load<ShipData>(StringKeeper.MainShipDataPath); // Get the speed value in data
        _speed = shipData.moveSpeed;*/

        _speed = .5f;
        minDistance = 3;
    }

    protected override void GetTargetPosition()
    {
        _targetPosition = PlayerCenter.Instance.transform.position;
    }

    protected override void Movement()
    {
        DetermineTargetPosition();

        if (IsMinDistance()) return;
        //Debug.Log(distance);

        FollowTarget();
    }

    public bool IsMinDistance()
    {
        var distance = Vector2.Distance(transform.parent.position, _targetPosition);
        return distance < minDistance;
    }
}