using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelByDistance : BaseLevel
{
    [SerializeField] protected Vector3 startPosition = Vector3.zero; // Điểm xuất phát
    [SerializeField] protected Vector3 currentPosition; // Điểm hiện tại
    [SerializeField] protected float distance;
    [SerializeField] protected float distancePerLevel;

    private void FixedUpdate() => Leveling();

    private void Leveling()
    {
        UpdateCurrentPosition();
        distance = Vector2.Distance(startPosition, currentPosition);
        var newLevel = Mathf.FloorToInt(distance / distancePerLevel);
        SetLevel(newLevel);
    }

    protected abstract void UpdateCurrentPosition();
}