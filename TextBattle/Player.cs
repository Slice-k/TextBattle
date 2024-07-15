public class Player
{
    public int MaxHP { get; private set; }
    public int CurrentHP { get; set; }
    public int MaxMana { get; private set; }
    public int CurrentMana { get; set; }
    public int HealthPotions { get; set; }
    public int StrengthPotions { get; set; }
    public int FireFlasks { get; set; }
    private Summoner summoner;
    private Warrior warrior;
    private Samurai samurai;
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
        summoner = new Summoner();
        warrior = new Warrior();
        samurai = new Samurai();
        rand = new Random();

        if (Build.SummonerBuild)
        {
            MaxHP = 75;
        }
        else if (Build.WarriorBuild)
        {
            MaxHP = 100;
        }
        else if (Build.SamuraiBuild)
        {
            MaxHP = 90;
        }
        else
        {
            MaxHP = 100;
        }

        CurrentHP = MaxHP;
    }

    public int GetBaseDamage()
    {
        if (Build.SummonerBuild)
        {
            return summoner.GetAtkDamage();
        }
        else if (Build.WarriorBuild)
        {
            return warrior.GetAtkDamage();
        }
        else if (Build.SamuraiBuild)
        {
            return samurai.GetAtkDamage();
        }
        else
        {
            DamageEffect damageEffect = new DamageEffect(6, 20);
            return damageEffect.CalculateDamage();
        }
    }

    public void Skills(Enemy enemy)
    {
        bool repeatSkillSelection;
        do
        {
            if (Build.SummonerBuild)
            {
                repeatSkillSelection = summoner.UseSkill(this, enemy);
            }
            else if (Build.WarriorBuild)
            {
                repeatSkillSelection = warrior.UseSkill(this, enemy);
            }
            else if (Build.SamuraiBuild)
            {
                repeatSkillSelection = samurai.UseSkill(this, enemy);
            }
            else
            {
                Console.WriteLine("Skills:\n");
                Console.WriteLine("1. Back\n2. Heavy Punch");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        repeatSkillSelection = false;
                        break;

                    case "2":
                        if (CurrentMana >= 15)
                        {
                            DamageEffect damageEffect = new DamageEffect(15, 20);
                            int damage = damageEffect.CalculateDamage();
                            enemy.CurrentHP -= damage;
                            CurrentMana -= 15;
                            Console.WriteLine("=== You used Heavy Punch and did " + damage + " damage! ===\n");
                            repeatSkillSelection = false;
                        }
                        else
                        {
                            Console.WriteLine("\n=== You do not have enough Mana ===");
                            repeatSkillSelection = true;
                        }
                        break;

                    default:
                        Console.WriteLine("=== Invalid Option ===");
                        repeatSkillSelection = true;
                        break;
                }
            }
        } while (repeatSkillSelection);
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
        StrengthPotions--;
    }
}