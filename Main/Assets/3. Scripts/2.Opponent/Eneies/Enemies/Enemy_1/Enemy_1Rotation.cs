using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using ChuongLibrary.Game2D;

public class Enemy_1Rotation : ChuongMono
{
    [SerializeField] private float rotSpeed;
    private void Update() => RotateShip();

    protected virtual void RotateShip()
        => LookAtTargetClass.GraduallyLookAtTarget(transform.parent, rotSpeed, PlayerCenter.Instance.transform);
}