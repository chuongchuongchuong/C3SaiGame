using UnityEngine;

public class ScriptBulletSpawner : BaseSpawner
{
    public static ScriptBulletSpawner Instance { get; private set; }

    public string bulletName;

    protected override void Reset()
    {
        base.Reset();
        spawnPlace = GameObject.Find("BulletSpawnPlace").transform;
        
    }
    private void Awake()
    {
        GuaranteeSingleton();
    }

    private void GuaranteeSingleton()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning("More than one " + GetType().Name + " in scene.");
            return;
        }

        Instance = this;
    }
}