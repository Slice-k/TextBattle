public class Items{

    public int HealthPotions { get; set; }
    public int StrengthPotions { get; set; }
    public int FireFlasks { get; set; }
    public int ManaPotions {get; set;}

public Items()
{
    HealthPotions = 3;
    StrengthPotions = 3;
    FireFlasks = 3;
    ManaPotions = 3;
}
public void ItemMenu(Player player, Enemy enemy)
    {
    var itemMenu = true;
    while(itemMenu)
        {
        Console.WriteLine("What item will you use?");
        Console.WriteLine("1. Back\n2. Health Potion (Uses: " + HealthPotions + ")\n3. Strength Potion (Uses: " + StrengthPotions + ")" + "\n4. Mana Potion (Uses: " + ManaPotions +")" + "\n5. Fire Flask (Uses: " + FireFlasks + ")");
        var itemSelect = Console.ReadLine();
        switch (itemSelect)
        {
            case "1":
            break;

            case "2":
            if (HealthPotions > 0)
            {
                UseHealthPotion(player);
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
                UseStrengthPotion(player);
                Game.ItemUsed = true;
            }
            else
            {
                Console.WriteLine("=== You have no more Strength Potions :( ===");
            }
            break;


            case "4":
            if (ManaPotions > 0)
            {
                UseManaPotion(player);
                Game.ItemUsed = true;
            }
            break;


            case "5":
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
    public void UseHealthPotion(Player player)
    {
        Console.WriteLine("=== You used a Health Potion and recovered 30 HP! ===");
        player.CurrentHP += 30;
        if (player.CurrentHP > player.MaxHP) player.CurrentHP = player.MaxHP; // so players HP won't exceed max when using health potion
        HealthPotions--;
    }

    public void UseFireFlask(Enemy enemy)
    {
        Console.WriteLine("=== You threw a Fire Flask at the " + enemy.Name + " and did 30 damage ===");
        enemy.CurrentHP -= 30;
        FireFlasks--;
    }

    public void UseStrengthPotion(Player player)
    {
        Console.WriteLine("=== You used a strength potion! === ");
        StrengthPotions--;
        foreach (var effect in player.Effects)
        {
            if(effect.Key == "Strength")
            {
                effect.Value.ApplyEffect();
            }
        }
    }
    public void UseManaPotion(Player player)
    {
        Console.WriteLine("=== You used a Mana Potion and recovered 50 MP! ===");
        player.CurrentMana += 50;
        if (player.CurrentMana > player.MaxMana) player.CurrentMana = player.MaxMana; // so players HP won't exceed max when using health potion
        ManaPotions--;
    }

}