using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    private void Update()
    {
        RotateShip();
    }

    protected virtual void RotateShip()
    {
        ChuongLibrary.Game2D.LookAtTargetClass.LookAtTarget(transform.parent,
            InputManager.Instance.mouseWorldPos, "");
    }
}