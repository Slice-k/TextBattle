using System;
class Program
{
    
    
    static void Main(string[] args)
    {
        
        string BuildChoice(string buildChoice)
    {
        string? build;
        switch(buildChoice)
    {
        case "1":
                build = "Summoner";
                break;
        case "2":
                build = "Warrior";
                break;
        case "3":
                build = "Samurai";
                break;
        case "4":
                build = "Calvin";
                break;
            default:
                Console.WriteLine("=== Invalid Option! ===");
                build = null;
                break;
    }
    return build;
    }

    Player? SelectBuild(string build)
    {   
        if(build == "Summoner")
        {
            return new Summoner();
        }
        else if(build == "Warrior"){
            return new Warrior();
        }
        else if(build == "Samurai"){
            return new Samurai();
        }
        else if (build == "Calvin")
        {
            return new Calvin();
        }
        else {
            return null;
        }
    }
        
        Random rand = new Random();
        bool gameLoop = true;
        
        List<Enemy> enemies = new List<Enemy>
        {
            new Enemy("Skeleton", 80, 1, 15), // min dmg 1, max dmg 15
            new Enemy("Wolf", 90, 5, 21), // min dmg 5, max dmg 21
            new Enemy("Goblin", 95, 1, 11), // min damage 1, max dmg 11
            new Enemy("New Yorker", 100, 1, 15), // min dmg 1, max dmg 15
            new Enemy("Sasquatch", 110, 10, 20), // min dmg 10, max dmg 20
            new Enemy("Garm", 125, 15, 25), // min dmg 15, max dmg 25
            new Enemy("Shabti", 75, 10, 30), // min dmg 10, max dmg 30
            new Enemy("Dragon", 135, 15, 20), // min dmg 15, max dmg 20
        };
       
       
       Player player = null;
       while(player == null)
       {
        Console.WriteLine("Choose your Class:\n1. Summoner\n2. Warrior\n3. Samurai \n4. Calvin"); // build choice
        var buildChoice = Console.ReadLine();
        player = SelectBuild(BuildChoice(buildChoice));
       }
        
        
        Game gameManager = new Game();

        while (gameLoop) // main game loop
        {
            Game.ItemUsed = false;
            int healthPotionDropChance = gameManager.GetPotionDropChance();
            int flaskDropChance = gameManager.GetFlaskDropChance();
            int manaPotionDropChance = gameManager.GetPotionDropChance();
            int turn = rand.Next(2); if(turn == 0) Game.PlayerTurn = true; else Game.EnemyTurn = true;
            var currentEnemy = enemies[rand.Next(enemies.Count)];
            currentEnemy.CurrentHP = currentEnemy.MaxHP;
            Console.WriteLine("\nYou've Encountered A " + currentEnemy.Name + "!");
            while (currentEnemy.CurrentHP >= 0 && gameLoop) // combat loop
            {   
                while (Game.PlayerTurn && currentEnemy.CurrentHP >= 0 && gameLoop) // player turn
                {
                    Console.WriteLine("\n- "+ player.Name+" -"); // player name
                    Console.WriteLine("HP: " + player.CurrentHP + "\nMP: " + player.CurrentMana); // player HP and MP
                    foreach(var effect in player.Effects) // buffs
                    {
                        if(effect.Value.active)
                        {
                            Console.WriteLine("Active Buffs: ");
                            if(effect.Key == "Strength")
                            {
                                Console.WriteLine("= Strength =");
                            }
                        }
                    }
                    Console.WriteLine("\n" + currentEnemy.Name + "'s HP: " + currentEnemy.CurrentHP); // Enemy HP
                    Console.WriteLine("\nWhat will you do?\n1. Attack\n2. Skills" + "\n3. Run\n4. Items"); // battle options
                    var option = Console.ReadLine();
                    switch (option)
                {
                    case "1":
                    
                    Console.WriteLine("\n=== You hit " + currentEnemy.Name + " for " + player.DealDamage(currentEnemy) + " damage! ==="); // player attack
                    player.CurrentMana += rand.Next(5, 15+1);
                    Game.hasAttacked(player);
                    Game.SwitchTurn();
                    break;


                    case "2":
                            player.UseSkill(currentEnemy);
                    continue;


                    case "3":
                        Console.WriteLine("You ran away!");
                        gameLoop = false;
                        break;


                    case "4":
                    if(!Game.ItemUsed)
                    {
                      player.items.ItemMenu(player, currentEnemy);
                    }
                    else
                    {
                        Console.WriteLine("=== You already used an item this turn. ===");
                    }
                        
                        continue; // continues loop so it's still players turn after they use an item
                        
                    
                        default: // any other option continues item select loop and tells player option is invalid
                                //  so it keeps them in the item menu until they press the back button or use an item they have available.
                        Console.WriteLine("=== Invalid Option! ===");
                        continue; 
                    }
                }
                    if(player.CurrentMana >= player.MaxMana) player.CurrentMana = player.MaxMana;
                    if(player.CurrentMana < 1) player.CurrentMana = 0;
                    Game.ItemUsed = false;
                    

                if (!gameLoop) // for the "run" option, so the enemy doesn't hit you after you run
                {
                    break;
                }
                if(currentEnemy.CurrentHP <= 0) // checks enemy health before enemy turn, so they can't kill you while their dead
                {
                    break;
                }
                    
                
                
                if (Game.EnemyTurn) // enemy turn logic
                {
                    int enemyAtkDmg = currentEnemy.GetAttackDamage();
                    player.CurrentHP -= enemyAtkDmg;
                    Console.WriteLine("=== " + currentEnemy.Name + " hits you for " + enemyAtkDmg + " damage! ===");
                    Game.SwitchTurn();
                }
                if (player.CurrentHP <= 0)
                {
                    Console.WriteLine("\nYou died D:");
                    gameLoop = false;
                    break;
                }
            }

                if (currentEnemy.CurrentHP <= 0)
            {
                Console.WriteLine("You defeated the " + currentEnemy.Name + "!");

                if(healthPotionDropChance <= 50)
                {
                    Console.WriteLine("=== The " + currentEnemy.Name + " Dropped a health potion! ===");
                    player.items.HealthPotions++;
                }
                if(flaskDropChance <= 30)
                {
                    Console.WriteLine("=== The " + currentEnemy.Name + " Dropped a fire flask! ===");
                    player.items.HealthPotions++;
                }
                if(manaPotionDropChance <= 50)
                {
                    Console.WriteLine("=== The " + currentEnemy.Name + " Dropped a mana potion! ===\n");
                    player.items.ManaPotions++;
                }

                // continue screen loop
                var continueScreen = true;
                while(continueScreen)
                {
                Console.WriteLine("Would you like to Continue?\n 1. Yes\n 2. No");
                var continueOption = Console.ReadLine();
                if (continueOption == "1")
                {
                    currentEnemy.CurrentHP = 100;
                    break;
                }
                else if (continueOption == "2")
                {
                    Console.WriteLine("Thank you for playing!");
                    gameLoop = false;
                    break;
                }
                else 
                {
                    Console.WriteLine("=== Inavlid Option! ===");
                    continue;
                }
            }
            }
                
            

            
        }

    }


    
}

