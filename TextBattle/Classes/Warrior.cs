public class Warrior : Player
{
    private Random rand = new Random();
   

    public Warrior()
    {
        MaxHP = 150;
        CurrentHP = MaxHP;
        Name = "Warrior";
    }
    
    public override int DealDamage(Enemy enemy)
    {
        int damage = GetDamage(1, 10);
        enemy.CurrentHP -= damage;
        return damage;
    }

    public override bool UseSkill(Enemy enemy)
    {

        bool repeatSkillSelection;

        do 
        {
        Console.WriteLine("Skills:\n");
        Console.WriteLine("1. Back\n2. Fell Cleave (MP Cost: 30)\n3. Equilibrium (MP Cost: 80)");
        var choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                return false;

            case "2":
            manaCost = 30;
                if (CurrentMana >= manaCost)
                {
                    FellCleave(enemy);
                    return false;
                }
                else
                {
                    Console.WriteLine("\n=== You do not have enough Mana ===");
                    return true;
                }

            case "3":
            manaCost = 80;
                if (CurrentMana >= manaCost)
                {
                    Equilibrium();
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
        } while (repeatSkillSelection);
        
    }


    public void FellCleave(Enemy enemy)
    {
                    skillDamage = GetDamage(20, 35);
                    enemy.CurrentHP -= skillDamage;
                    CurrentMana -= manaCost;
                    Console.WriteLine("\n=== You used Fell Cleave and did " + skillDamage + " damage! ===");
                    Game.hasAttacked(this);
                    Game.SwitchTurn();
    }
    public void Equilibrium()
    {
                    int heal = GetDamage(60, 90);
                    CurrentHP += heal;
                    CurrentMana -= 80;
                    if (CurrentHP >= MaxHP) CurrentHP = MaxHP;
                    Console.WriteLine("\n=== You used Equilibrium and healed for " + heal + " HP ===");
                    Game.hasAttacked(this);
    }
}