using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public abstract class BaseHealth : ChuongPrefabs
{
    protected int maxHealth; // biến cần gán trong class con
    public int healthPoint;
    public bool isReceiveDamage = true;

    protected override void ResetValues_Awake()
    {
        healthPoint = maxHealth;
    }

    public void TakeDamage(int damage) // nhận sát thương
    {
        if (!isReceiveDamage) return;
        
        healthPoint -= damage;
        if (healthPoint < 0) healthPoint = 0;
    }

    public void HealHealth(int heal) // Hồi máu
    {
        healthPoint += heal;
        if (healthPoint > maxHealth) healthPoint = maxHealth;
    }

    public bool IsDead() => (healthPoint == 0); // máu ít hơn 0 thì chết
}