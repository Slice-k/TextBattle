public class Enemy
{

    public string Name { get; }
    public int MaxHP { get; }
    public int CurrentHP { get; set; }
    public int MinAttackDamage { get; }
    public int MaxAttackDamage { get; }
    public Effect effect; // :/

    private Random rand;

    public Enemy(string name, int maxHP, int minAttackDamage, int maxAttackDamage)
    {
        Name = name;
        MaxHP = maxHP;
        CurrentHP = maxHP;
        MinAttackDamage = minAttackDamage;
        MaxAttackDamage = maxAttackDamage;
        rand = new Random();
    }

    public int GetAttackDamage()
    {
        return rand.Next(MinAttackDamage, MaxAttackDamage + 1);
    }
}