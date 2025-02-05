using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using ChuongLibrary.Game2D;

public class Enemy_1Model : ChuongMono
{
    #region Get Object Center

    [SerializeField] private Enemy_1Center enemy1Center;
    protected override void LoadObjectCenter() => enemy1Center = transform.parent.GetComponent<Enemy_1Center>();

    #endregion

    public Tween scaleTween;

    [SerializeField] private float rotSpeed;

    [SerializeField] private float appearDuration = 3;
    private Vector3 initScale = Vector3.zero;
    private Vector3 startScale = Vector3.one;

    private void Update() => RotateShip();

    protected virtual void RotateShip()
    {
        LookAtTargetClass.GraduallyLookAtTarget(transform.parent, rotSpeed, PlayerCenter.Instance.transform);
    }

    public void AppearScale()
    {
        OnAppearStart();
        
        // Đặt localScale ban đầu của vật thể thành (0, 0, 0)
        transform.parent.localScale = initScale;

        // Sử dụng DOTween để phóng to vật thể từ (0, 0, 0) đến (1, 1, 1) trong thời gian `duration`
        scaleTween = transform.parent.DOScale(startScale, appearDuration).SetEase(Ease.Linear). // Tạo tween phóng to
            OnComplete(OnAppearFinish);
    }

    protected void OnAppearStart()
    {
        enemy1Center.shooting.enabled = false;
        enemy1Center.movement_FollowTarget.enabled = false;
    }
    protected void OnAppearFinish()
    {
        enemy1Center.shooting.enabled = true;
        enemy1Center.movement_FollowTarget.enabled = true;
    }
}