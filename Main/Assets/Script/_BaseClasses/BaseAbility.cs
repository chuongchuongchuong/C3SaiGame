using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public abstract class BaseAbility : ChuongMono
{
    // @formatter:off
    [Header("Base Ability")]
    [SerializeField] protected float lastTimeUse;
    [SerializeField] protected float cooldownTime;
    // @formatter:on

    protected override void Awake_ResetValues() => cooldownTime = GetCooldownTime();

    protected abstract float GetCooldownTime();

    protected virtual void FixedUpdate() => CanUseAbilityThenUse();

    protected virtual void CanUseAbilityThenUse()
    {
        if (CanUse()) UseAbility();
    }

    protected virtual bool CanUse() => Time.time - lastTimeUse > cooldownTime;

    protected abstract void UseAbility();
}