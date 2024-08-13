public class Game

{

    public static bool ItemUsed {get; set;}
    public static bool PlayerTurn {get; set;}
    public static bool EnemyTurn {get; set;}
    Random rand = new Random();
    public Game()
    {
        ItemUsed = false;
    }


public int GetPotionDropChance()
{
    return rand.Next(1, 100+1);
}

public int GetFlaskDropChance()
{
    return rand.Next(1, 100+1);
}

public static void SwitchTurn()
{
    if(PlayerTurn)
    {
        PlayerTurn = false;
        EnemyTurn = true;
    }
    else if(Game.EnemyTurn)
    {
        EnemyTurn = false;
        PlayerTurn = true;
        
    }
}

public static void hasAttacked(Player player)
{
    player.Effects["Strength"].Tick();
}
}