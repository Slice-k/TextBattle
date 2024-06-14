public class Player
{
    public int MaxHP { get; private set; }
    public int CurrentHP { get; set; }
    public int MaxMana {get; private set;}
    public int CurrentMana {get; set;}
    public int HealthPotions { get; set; }
    public int StrengthPotions {get; set; }
    public int FireFlasks { get; set; }
    public bool Strengthened {get; set;}
    public int StrengthCounter {get; set;}
    private Random rand;

    public Build Build;

    public Game gameManager;

    public Player(Build build)
    {
        gameManager = new Game();
        Build = build;
        MaxMana = 100;
        CurrentMana = MaxMana;
        HealthPotions = 3;
        StrengthPotions = 3;
        FireFlasks = 3;
        Strengthened = false;
        StrengthCounter = 3;
        rand = new Random();

        if (Build.SummonerBuild)
        {
            MaxHP = 75;
        }
        else if (Build.WarriorBuild)
        {
            MaxHP = 200;
        }
        else if(Build.SamuraiBuild)
        {
            MaxHP = 90;
        }
        else 
        {
            MaxHP = 100;
        }

        CurrentHP = MaxHP;
    }

    public int GetAttackDamage()
    {
        if (Build.SummonerBuild)
        {
            if(Strengthened)
            {
                return rand.Next(11, 25+1); // min damage 11, max damage 25
            }
            else{
                return rand.Next(6, 20+1); // min damage 6, max damage 20
            }
            
        }
        else if (Build.WarriorBuild)
        {
            if(Strengthened)
            {
                return rand.Next(6, 15+1); // min dmg 6, max dmg 15
            }
            else
            {
            return rand.Next(10) + 1; // min damage 1, max damage 10
            }
        }
        else if(Build.SamuraiBuild)
        {
            if(Strengthened)
            {
                return rand.Next(15, 30+1); // min damage 15, max 30
            }
            return rand.Next(10, 25+1); // min damage 10, max 25
        }
        else
        {
            if(Strengthened)
            {
                return rand.Next(6, 20+1); // min damage 6
            }
            return rand.Next(15) + 1; // min damage 1, max damage 15
        }
    }


public void Skills(Enemy enemy)
{
    var skillMenu = true;
    while(skillMenu)
    {
    if(Build.SummonerBuild)
    {
        Console.WriteLine("Skills:\n");
        Console.WriteLine("1. Back\n2. Summon Carby (MP Cost: 20)");
        var choice = Console.ReadLine();
        switch(choice)
        {
            case "1":
            break;

            case "2":
            if(CurrentMana >= 20)
            {
            var damage = rand.Next(30, 45+1);
            enemy.CurrentHP -= damage;
            CurrentMana -= 20;
            Console.WriteLine("=== You summoned Carby to hit " + enemy + " for " + damage + " damage! ===");
            Game.SwitchTurn();
            }
            else
            {
                Console.WriteLine("=== You do not have enough Mana ===");
            }
            break;

            default:
            Console.WriteLine("=== Invalid Option ===");
            continue;
        }
    }

    else if(Build.WarriorBuild)
    {
        Console.WriteLine("Skills:");
        Console.WriteLine("1. Back\n2. Fell Cleave (MP Cost: 30)\n3. Equilibrium (MP Cost: 75)");
        var choice = Console.ReadLine();
        switch(choice)
        {
            case "1":
            break;

            case "2":
            if(CurrentMana >= 30)
            {
            var damage = rand.Next(20, 35+1);
            enemy.CurrentHP -= damage;
            CurrentMana -= 30;
            Console.WriteLine("\n=== You used Fell Cleave and did " + damage + " damage! ===\n");
            Game.SwitchTurn();
            }
            else {
                Console.WriteLine("\n=== You do not have enough Mana ===");
            }
            
            break;

            case "3":
            if(CurrentMana >= 75)
            {
            var heal = rand.Next(60, 90+1);
            CurrentHP += heal;
            CurrentMana -= 80;
            if(CurrentHP >= MaxHP)  CurrentHP = MaxHP;
            Console.WriteLine("\n=== You used Equilibrium and healed for " + heal + " HP ===");
            }
            else{
                Console.WriteLine("\n=== You do not have enough Mana ===");
            }
            break;

            default:
            Console.WriteLine("\n=== Invalid Option ===");
            continue;
        }
    }
    else if(Build.SamuraiBuild)
    {
        Console.WriteLine("Skills:\n");
        Console.WriteLine("1. Back\n2. Midare Setsugekka (MP Cost: 40)");
        var choice = Console.ReadLine();
        switch(choice)
        {
            case "1":
            break;

            case "2":
            if(CurrentMana >= 40)
            {
            var damage = rand.Next(40, 60+1);
            enemy.CurrentHP -= damage;
            CurrentMana -= 40;
            Console.WriteLine("\n=== You used Midare Setsugekka and did " + damage + " damage! ===\n");
            Game.SwitchTurn();
            }
            else {
                Console.WriteLine("\n=== You do not have enough Mana ===");
            }
            break;

            default:
            Console.WriteLine("=== Invalid Option ===");
            continue;
        }
    }
    
    else
    {
        Console.WriteLine("Skills:\n");
        Console.WriteLine("1. Back\n2. Heavy Punch");
        var choice = Console.ReadLine();
        switch(choice)
        {
            case "1":
            break;

            case "2":
            if(CurrentMana >= 15)
            {
            var damage = rand.Next(15, 20+1);
            enemy.CurrentHP -= damage;
            CurrentMana -= 15;
            Console.WriteLine("=== You used Heavy Punch and did " + damage + " damage! ===\n");
            }
            else{
                Console.WriteLine("\n=== You do not have enough Mana ===");
            }
            break;

            default:
            Console.WriteLine("=== Invalid Option ===");
            continue;
        }
    }
    break; // breaks out of skill menu loop when skill is used
    }
    
}
    


    public void ItemMenu(Enemy enemy)
    {
    var itemMenu = true;
    while(itemMenu)
        {
        Console.WriteLine("What item will you use?");
        Console.WriteLine("1. Back\n2. Health Potion (Uses: " + HealthPotions + ")\n3. Strength Potion (Uses: " + StrengthPotions + ")" + "\n4. Fire Flask (Uses: " + FireFlasks + ")");
        var itemSelect = Console.ReadLine();
        switch (itemSelect)
        {
            case "1":
            break;

            case "2":
            if (HealthPotions > 0)
            {
                UseHealthPotion();
                Game.ItemUsed = true;
            }
            else 
            {
                Console.WriteLine("=== You have no more health potions :( ===");
            }
            break;

            case "3":
            if(StrengthPotions > 0)
            {
                UseStrengthPotion();
                Game.ItemUsed = true;
            }
            else
            {
                Console.WriteLine("=== You have no more Strength Potions :( ===");
            }
            break;

            case "4":
            if (FireFlasks > 0)
            {
                UseFireFlask(enemy);
                Game.ItemUsed = true;
            }
            else
            {
                Console.WriteLine("=== You have no more Fire Flasks :( ===");
            }
            break;
                            
            default:
            Console.WriteLine("=== Invalid Option! ===");
            continue;
        }
        break; // breaks out of item select loop, after item use
        }
    }
    public void UseHealthPotion()
    {
        Console.WriteLine("=== You used a Health Potion and recovered 30 HP! ===");
        CurrentHP += 30;
        if (CurrentHP > MaxHP) CurrentHP = MaxHP; // so players HP won't exceed max when using health potion
        HealthPotions--;
    }

    public void UseFireFlask(Enemy enemy)
    {
        Console.WriteLine("=== You threw a Fire Flask at the " + enemy.Name + " and did 30 damage ===");
        enemy.CurrentHP -= 30;
        FireFlasks--;
    }

    public void UseStrengthPotion()
    {
        Console.WriteLine("=== You used a strength potion! === ");
        Strengthened = true;
        StrengthPotions--;
    }
}