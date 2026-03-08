// Player class inherits from Character
public class Player : Character
{
    public Player(int health, int str, int def, int dex)
        : base(health, str, def, dex)
    {
    }

    // Allows class selection to change stats
    public void SetStats(int hp, int str, int def, int dex)
    {
        MaxHealth = hp;
        CurrentHealth = hp;
        Strength = str;
        Defense = def;
        Dexterity = dex;
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
        CurrentHealth += 15;

        if (CurrentHealth > MaxHealth)
            CurrentHealth = MaxHealth;
    }
}