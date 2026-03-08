using UnityEngine;

// Base class for both Player and Enemy
public class Character
{
    public int MaxHealth;
    public int CurrentHealth;

    public int Strength;
    public int Defense;
    public int Dexterity;

    public bool IsDefending = false;

    public Character(int health, int str, int def, int dex)
    {
        MaxHealth = health;
        CurrentHealth = health;
        Strength = str;
        Defense = def;
        Dexterity = dex;
    }

    // Reduces health when taking damage
    public virtual void TakeDamage(int damage)
    {
        // If defending, reduce incoming damage
        if (IsDefending)
        {
            damage /= 2;
        }

        // Apply defense stat
        CurrentHealth -= Mathf.Max(damage - Defense, 0);

        // Prevent negative HP
        if (CurrentHealth < 0)
            CurrentHealth = 0;

        // Defend only lasts one hit
        IsDefending = false;
    }

    public bool IsDead()
    {
        return CurrentHealth <= 0;
    }
}