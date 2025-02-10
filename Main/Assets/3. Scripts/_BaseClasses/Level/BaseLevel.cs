using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseLevel : MonoBehaviour
{
    [Header("Level")] [SerializeField] protected int currentLevel = 1;
    [SerializeField] protected int maxLevel = 99;

    public virtual void LevelUp()
    {
        if (currentLevel == maxLevel) return;
        currentLevel++;
    }

    public virtual void LevelDown()
    {
        if (currentLevel == 1) return;
        currentLevel--;
    }

    public virtual void SetLevel(int level)
    {
        if (level > maxLevel) return;
        if (level < 1) return;
        currentLevel = level;
    }
}