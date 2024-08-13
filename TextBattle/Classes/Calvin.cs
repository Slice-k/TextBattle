public class Calvin : Player
{
    public Calvin()
    {
        MaxHP = 100;
        CurrentHP = 50;
        Name = "Calvin";
    }


    public override int DealDamage(Enemy enemy)
    {
        int damage = GetDamage(0, 0);
        enemy.CurrentHP -= damage;
        return damage;
    }

    public override bool UseSkill(Enemy enemy)
    {
        bool repeatSkillSelection;
        do {
        Console.WriteLine("Skills:\n");
        Console.WriteLine("1. Back\n2. Grip (MP Cost: 100)");
        var choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                return false;

            case "2":
            manaCost = 100;
                if (CurrentMana >= manaCost)
                {
                    skillDamage = GetDamage(0, enemy.CurrentHP);
                    enemy.CurrentHP -= skillDamage;
                    CurrentMana -= manaCost;
                    Console.WriteLine("\n=== You used Grip and did " + skillDamage + " damage! ===");
                    Game.hasAttacked(this);
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

