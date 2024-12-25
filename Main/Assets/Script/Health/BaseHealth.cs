using UnityEngine;
using UnityEngine.UI;

public abstract class BaseHealth : ChuongPrefabs
{
    protected int maxHealth; // biến cần gán trong class con
    [SerializeField] private int hp;

    protected override void Awake_ResetValues()
    {
        hp = maxHealth;
    }

    public void TakeDamage(int damage) // nhận sát thương
    {
        hp -= damage;
        if (hp < 0) hp = 0;
    }

    public void HealHealth(int heal) // Hồi máu
    {
        hp += heal;
        if (hp > maxHealth) hp = maxHealth;
    }

    public bool IsDead() => (hp == 0); // máu ít hơn 0 thì chết
}