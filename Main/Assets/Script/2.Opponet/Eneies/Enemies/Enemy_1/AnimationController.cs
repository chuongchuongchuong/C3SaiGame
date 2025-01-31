using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimationController : ChuongMono
{
    #region Get Object Center

    [SerializeField] private Enemy_1Center enemy1Center;
    protected override void Reset_LoadObjectCenter() => enemy1Center = transform.parent.GetComponent<Enemy_1Center>();

    #endregion

    [SerializeField] private float appearDuration = 3;
    private Vector3 initScale = Vector3.zero;
    private Vector3 startScale = Vector3.one;

    protected void OnEnable()
    {
        this.OnAppearStart();

        // Đặt localScale ban đầu của vật thể thành (0, 0, 0)
        transform.parent.localScale = initScale;

        // Sử dụng DOTween để phóng to vật thể từ (0, 0, 0) đến (1, 1, 1) trong thời gian `duration`
        transform.parent.DOScale(startScale, appearDuration).SetEase(Ease.Linear). // Tạo tween phóng to
            OnComplete(OnAppearFinish);
    }

    protected void OnAppearStart()
    {
        enemy1Center.shooting.gameObject.SetActive(false);
    }

    protected void OnAppearFinish()
    {
        enemy1Center.shooting.gameObject.SetActive(true);
    }
}