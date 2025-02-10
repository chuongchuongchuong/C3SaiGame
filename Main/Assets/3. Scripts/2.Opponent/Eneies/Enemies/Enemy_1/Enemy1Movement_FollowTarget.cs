using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Movement_FollowTarget : MovementFollowTarget
{
    [SerializeField] private float minDistance;

    protected override void Awake_ResetValues()
    {
        /*var shipData = Resources.Load<ShipData>(StringKeeper.MainShipDataPath); // Get the speed value in data
        _speed = shipData.moveSpeed;*/

        _speed = .5f;
        minDistance = 2;
    }

    protected override Vector3 GetTargetPosition() => PlayerCenter.Instance.transform.position;

    protected override void Update()
    {
        if (IsMinDistance()) return;
        //Debug.Log(distance);

        FollowTarget();
    }

    public bool IsMinDistance()
    {
        var distance = Vector2.Distance(transform.parent.position, GetTargetPosition());
        return distance < minDistance;
    }
}