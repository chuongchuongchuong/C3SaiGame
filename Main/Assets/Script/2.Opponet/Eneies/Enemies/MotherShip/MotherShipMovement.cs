using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipMovement : ChuongMono
{
    #region Get Object Center

    [SerializeField] private PlayerCenter player;
    protected override void Reset_LoadObjectCenter() => player = PlayerCenter.Instance;

    public float rotSpeed = 2f;

    #endregion
    private void Update()
    {
        ChuongLibrary.Game2D.LookAtTargetClass.GraduallyLookAtTarget(transform.parent, rotSpeed,player.transform,-90);
    }
}
