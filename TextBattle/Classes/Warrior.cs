public class Warrior
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
        Console.WriteLine("1. Back\n2. Fell Cleave (MP Cost: 30)\n3. Equilibrium (MP Cost: 80)");
        var choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                return false;

            case "2":
                if (player.CurrentMana >= 30)
                {
                    DamageEffect damageEffect = new DamageEffect(20, 35);
                    int damage = damageEffect.CalculateDamage();
                    enemy.CurrentHP -= damage;
                    player.CurrentMana -= 30;
                    Console.WriteLine("\n=== You used Fell Cleave and did " + damage + " damage! ===\n");
                    Game.SwitchTurn();
                    return false;
                }
                else
                {
                    Console.WriteLine("\n=== You do not have enough Mana ===");
                    return true;
                }

            case "3":
                if (player.CurrentMana >= 80)
                {
                    DamageEffect healEffect = new DamageEffect(60, 90);
                    int heal = healEffect.CalculateDamage();
                    player.CurrentHP += heal;
                    player.CurrentMana -= 80;
                    if (player.CurrentHP >= player.MaxHP) player.CurrentHP = player.MaxHP;
                    Console.WriteLine("\n=== You used Equilibrium and healed for " + heal + " HP ===");
                    return false;
                }
                else
                {
                    Console.WriteLine("\n=== You do not have enough Mana ===");
                    return true;
                }

            default:
                Console.WriteLine("\n=== Invalid Option ===");
                return true;
        }
    }
}