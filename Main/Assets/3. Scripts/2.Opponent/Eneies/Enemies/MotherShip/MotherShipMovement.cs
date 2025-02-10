using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipMovement : ChuongMono
{
    #region Get Object Center

    [SerializeField] private PlayerCenter player;

    protected override void LoadObjectCenter() => player ??= PlayerCenter.Instance;

    #endregion
}