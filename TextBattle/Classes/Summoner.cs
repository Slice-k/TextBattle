public class Summoner
{
    private Random rand = new Random();

    public int GetAtkDamage()
    {
        DamageEffect damageEffect = new DamageEffect(6, 20);
        return damageEffect.CalculateDamage();
    }

    public bool UseSkill(Player player, Enemy enemy)
    {
        Console.WriteLine("Skills:\n");
        Console.WriteLine("1. Back\n2. Summon Carby (MP Cost: 20)");
        var choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                return false;

            case "2":
                if (player.CurrentMana >= 20)
                {
                    DamageEffect damageEffect = new DamageEffect(30, 45);
                    int damage = damageEffect.CalculateDamage();
                    enemy.CurrentHP -= damage;
                    player.CurrentMana -= 20;
                    Console.WriteLine("=== You summoned Carby to hit " + enemy.Name + " for " + damage + " damage! ===");
                    Game.SwitchTurn();
                    return false;
                }
                else
                {
                    Console.WriteLine("=== You do not have enough Mana ===");
                    return true;
                }

            default:
                Console.WriteLine("=== Invalid Option ===");
                return true;
        }
    }
}