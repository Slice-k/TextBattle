public class Samurai : Player
{
    private Random rand = new Random();
 

    public Samurai()
    {
        MaxHP = 95;
        CurrentHP = MaxHP;
        Name = "Samurai";
    }

    public override int DealDamage(Enemy enemy)
    {
        int damage = GetDamage(8, 25);
        enemy.CurrentHP -= damage;
        return damage;

    }


    public override bool UseSkill(Enemy enemy)
    {
        bool repeatSkillSelection;
        do {
        Console.WriteLine("Skills:\n");
        Console.WriteLine("1. Back\n2. Midare Setsugekka (MP Cost: 40)");
        var choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                return false;

            case "2":
                if (CurrentMana >= 40)
                {
                    int damage = GetDamage(40, 60);
                    enemy.CurrentHP -= damage;
                    CurrentMana -= 40;
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
        } while (repeatSkillSelection);
        
    }
}
