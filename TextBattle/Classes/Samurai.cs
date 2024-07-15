public class Samurai
{
    private Random rand = new Random();

    public int GetAtkDamage()
    {
        DamageEffect damageEffect = new DamageEffect(1, 15);
        return damageEffect.CalculateDamage();
    }

    public bool UseSkill(Player player, Enemy enemy)
    {
        Console.WriteLine("Skills:\n");
        Console.WriteLine("1. Back\n2. Midare Setsugekka (MP Cost: 40)");
        var choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                return false;

            case "2":
                if (player.CurrentMana >= 40)
                {
                    DamageEffect damageEffect = new DamageEffect(40, 60);
                    int damage = damageEffect.CalculateDamage();
                    enemy.CurrentHP -= damage;
                    player.CurrentMana -= 40;
                    Console.WriteLine("\n=== You used Midare Setsugekka and did " + damage + " damage! ===\n");
                    Game.SwitchTurn();
                    return false;
                }
                else
                {
                    Console.WriteLine("\n=== You do not have enough Mana ===");
                    return true;
                }

            default:
                Console.WriteLine("=== Invalid Option ===");
                return true;
        }
    }
}
