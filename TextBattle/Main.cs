using System;
class Program
{
    
    static void Main(string[] args)
    {
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
       
        Console.WriteLine("Choose your Class:\n1. Summoner\n2. Warrior\n3. Samurai"); // build choice
        var buildChoice = Console.ReadLine();


        Build build = new Build(buildChoice);
        Player player = new Player(build);
        Game gameManager = new Game();

        while (gameLoop) // main game loop
        {
            Game.ItemUsed = false;
            int potionDropChance = gameManager.GetPotionDropChance();
            int flaskDropChance = gameManager.GetFlaskDropChance();
            int turn = rand.Next(2); if(turn == 0) Game.PlayerTurn = true; else Game.EnemyTurn = true;
            var currentEnemy = enemies[rand.Next(enemies.Count)];
            currentEnemy.CurrentHP = currentEnemy.MaxHP;
            Console.WriteLine("\nYou've Encountered A " + currentEnemy.Name + "!\n");
            while (currentEnemy.CurrentHP >= 0 && gameLoop) // combat loop
            {
            int playerAtkDmg = player.GetBaseDamage();
                
                
                while (Game.PlayerTurn && currentEnemy.CurrentHP >= 0 && gameLoop) // player turn
                {
                    
                    Console.WriteLine("- "+build.Name+" -");
                    Console.WriteLine("HP: " + player.CurrentHP + "\nMP: " + player.CurrentMana);
                    Console.WriteLine(currentEnemy.Name + "'s HP: " + currentEnemy.CurrentHP + "\n");
                    Console.WriteLine("What will you do?\n1. Attack\n2. Skills" + "\n3. Run\n4. Items");
                    var option = Console.ReadLine();
                    switch (option)
                {
                    case "1":
                    
                    currentEnemy.CurrentHP -= playerAtkDmg;
                    Console.WriteLine("\n=== You hit " + currentEnemy.Name + " for " + playerAtkDmg + " damage! ===\n");
                    player.CurrentMana += rand.Next(5, 15+1);
                    Game.SwitchTurn();
                    break;


                    case "2":
                            
                            player.Skills(currentEnemy);
                    continue;


                    case "3":
                        Console.WriteLine("You ran away!");
                        gameLoop = false;
                        break;


                    case "4":
                    if(!Game.ItemUsed)
                    {
                      player.ItemMenu(currentEnemy);
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
                    Console.WriteLine("=== " + currentEnemy.Name + " hits you for " + enemyAtkDmg + " damage! ===\n");
                    Game.SwitchTurn();
                }
                if (player.CurrentHP <= 0)
                {
                    Console.WriteLine("You died D:");
                    gameLoop = false;
                    break;
                }
            }

                if (currentEnemy.CurrentHP <= 0)
            {
                Console.WriteLine("You defeated the " + currentEnemy.Name + "!\n");

                if(potionDropChance <= 50)
                {
                    Console.WriteLine("=== The " + currentEnemy.Name + " Dropped a health potion! ===\n");
                    player.HealthPotions++;
                }
                if(flaskDropChance <= 30)
                {
                    Console.WriteLine("=== The " + currentEnemy.Name + " Dropped a fire flask! ===\n");
                    player.HealthPotions++;
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

