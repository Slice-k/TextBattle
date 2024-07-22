public abstract class Player
{

    public int MaxHP { get; set; }
    public int CurrentHP { get; set;}    
    public string Name {get; set;}
    public int MaxMana { get; private set; }
    public int CurrentMana { get; set; }
    public int HealthPotions { get; set; }
    public int StrengthPotions { get; set; }
    public int FireFlasks { get; set; }

    public List<Effect> activeEffects;

    private Random rand;

    public Game gameManager;

    public Player()
    {
        gameManager = new Game();
        MaxMana = 100;
        CurrentMana = MaxMana;
        HealthPotions = 3;
        StrengthPotions = 3;
        FireFlasks = 3;
        rand = new Random();
    }

    public int GetDamage(int minDamage, int maxDamage)
    {
        return rand.Next(minDamage, maxDamage + 1);
    }

    public abstract bool UseSkill(Enemy enemy);

    public abstract int DealDamage(Enemy enemy);
    


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