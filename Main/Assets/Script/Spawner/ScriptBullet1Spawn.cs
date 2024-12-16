using UnityEngine;

public class ScriptBullet1Spawn : BaseSpawner<ScriptBullet1Spawn>
{
    public string bulletName;

    protected override void LoadComponent()
    {
        spawnHolder = GameObject.Find("BulletSpawnHolder").transform;
    }
}