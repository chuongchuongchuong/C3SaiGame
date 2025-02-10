using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Movement_Forward : ChuongMono
{
    private float normalSpeed;
    [SerializeField] private float speed;
    [SerializeField] private Transform forwardObj;

    #region Get Player Center

    [SerializeField] private PlayerCenter playerCenter;
    protected override void LoadObjectCenter() => playerCenter ??= PlayerCenter.Instance;

    #endregion

    protected override void Reset_LoadObjects() => forwardObj = transform.GetChild(0);

    protected override void Awake_ResetValues()
    {
        normalSpeed = 3;
        speed = normalSpeed;
    }

    private void Update() => MoveForward();

    // @formatter:off
    private void MoveForward()
    {
        var distance = Vector2.Distance(transform.parent.position, playerCenter.transform.position);
        if (distance < .1f) return;
        speed = (distance < 1f) ?
            0.1f : normalSpeed;

        transform.parent.position = Vector3.MoveTowards(transform.parent.position, forwardObj.position,
            speed * Time.deltaTime);
    }
    // @formatter:on
}