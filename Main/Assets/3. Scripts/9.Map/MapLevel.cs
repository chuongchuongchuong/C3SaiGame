using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLevel : LevelByDistance
{
    [SerializeField] PlayerCenter player;

    private void Reset()
    {
        player = PlayerCenter.Instance;
        distancePerLevel = 10;
    }

    protected override void UpdateCurrentPosition() => currentPosition = player.transform.position;
}