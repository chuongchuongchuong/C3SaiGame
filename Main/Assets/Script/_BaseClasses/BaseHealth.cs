using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public abstract class BaseHealth : ChuongMono
{
    [SerializeField] protected int maxHealth; // biến cần gán trong class con
    public int healthPoint;
    public bool isReceiveDamage = true;

    protected override void Awake_ResetValues() => healthPoint = maxHealth;

    public virtual void TakeDamage(int damage) // nhận sát thương
    {
        if (!isReceiveDamage) return;
        
        healthPoint -= damage;
        if (healthPoint < 0) healthPoint = 0;
    }

    public virtual void HealHealth(int heal) // Hồi máu
    {
        healthPoint += heal;
        if (healthPoint > maxHealth) healthPoint = maxHealth;
    }

    public virtual bool IsDead() => healthPoint == 0; // máu ít hơn 0 thì chết
}