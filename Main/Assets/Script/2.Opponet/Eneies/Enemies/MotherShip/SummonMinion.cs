using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonMinion : BaseAbility
{
    [SerializeField] private List<Transform> enemies;
    [SerializeField] private int enemySpawnedLimit = 4;
    protected override float GetCooldownTime() => 2f;
    protected override void UseAbility() => Summon();

    [ContextMenu("Summon")]
    protected void Summon()
    {
        var enemy = EnemyPoolObject.Instance.Spawn(EnemyList.Instance.List[0], transform.parent.position,
            Quaternion.identity);

        enemies.Add(enemy);
        lastTimeUse = Time.time;
    }

    protected override bool CanUse()
    {
        if (IsEnemySpawnedLimited()) return false;
        
        return base.CanUse();
    }

    private bool IsEnemySpawnedLimited()
    {
        //clear dead enemies out of the list
        for (var i = 0; i < enemies.Count; i++)
        {
            if (!enemies[i].gameObject.activeSelf) enemies.Remove(enemies[i]);
        }
        
        return enemies.Count >= enemySpawnedLimit;
    }
}