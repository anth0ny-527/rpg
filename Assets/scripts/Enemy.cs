using UnityEngine;

// Enemy class inherits from Character
public class Enemy : Character
{
    public Enemy(int health, int str, int def, int dex)
        : base(health, str, def, dex)
    {
    }

    public int Attack()
    {
        return Strength * 2;
    }

    public void Defend()
    {
        IsDefending = true;
    }

    public void Heal()
    {
        CurrentHealth += 5;

        if (CurrentHealth > MaxHealth)
            CurrentHealth = MaxHealth;
    }

    // Randomly chooses action each turn
    public int ChooseAction()
    {
        return Random.Range(0, 3); // 0 = attack, 1 = defend, 2 = heal
    }
}