using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : BaseCollider
{
    [Header("PlayerCollider")]
    [SerializeField] protected PlayerCenter playerCenter;
    public PickableItem pickableItem;

    protected override void LoadComponents_ResetInPrefab()
    {
        base.LoadComponents_ResetInPrefab();
        playerCenter = transform.parent.GetComponent<PlayerCenter>();
    }

    protected override void Awake_ResetValues()
    {
        var circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.radius = 0.2f;
    }

    protected override void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (!CanLoot(hitInfo)) return;
        LootItem();
    }
    
    protected virtual bool CanLoot(Collider2D hitInfo)
    {
        if (playerCenter.looter == null) return false;
        pickableItem = hitInfo.GetComponent<PickableItem>();
        if (pickableItem == null) return false;

        return true;
    }

    protected virtual void LootItem() => playerCenter.looter.Loot(pickableItem);
}