public class Summoner : Player
{
    private Random rand = new Random();





    public Summoner()
    {
        MaxHP = 75;
        CurrentHP = MaxHP;
        Name = "Summoner";
    }

    public override int DealDamage(Enemy enemy)
    {
        int damage = GetDamage(6, 20);
        enemy.CurrentHP -= damage;
        return damage;
    }

    public override bool UseSkill(Enemy enemy)
    {
        bool repeatSkillSelection;
        do {
        Console.WriteLine("Skills:\n");
        Console.WriteLine("1. Back\n2. Summon Carby (MP Cost: 20)");
        var choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
            Console.Clear();
                return false;

            case "2":
                if (CurrentMana >= 20)
                {
                    int damage = GetDamage(30, 45);
                    enemy.CurrentHP -= damage;
                    CurrentMana -= 20;
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
    } while (repeatSkillSelection);
    
    }
}