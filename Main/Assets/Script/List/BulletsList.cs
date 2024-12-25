using System;
using UnityEngine;
using System.Collections.Generic;

public class BulletsList : BaseList<BulletsList>
{
    protected override void UpdateIndex()
    {
        if (InputManager.Instance.ChangeToBullet_1Button()) index = 1;
        if (InputManager.Instance.ChangeToBullet_2Button()) index = 2;
    }
}