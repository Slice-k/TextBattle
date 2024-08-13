public abstract class Player : ISkills
{

    public string skillName {get; set;}
    public int skillDamage {get; set;}
    public int manaCost {get; set;}
    public int MaxHP { get; set; }
    public int CurrentHP { get; set;}    
    public string Name {get; set;}
    public int MaxMana { get; private set; }
    public int CurrentMana { get; set; }
    public Items items;
    public Dictionary<string, Effect> Effects {get; set;}

    private Random rand;

    public Game gameManager;

    public Player()
    {
        gameManager = new Game();
        MaxMana = 100;
        CurrentMana = MaxMana;
        rand = new Random();
        items = new Items();
        Effects = new Dictionary<string, Effect>
        {
            {"Strength", new StrengthEffect(3)}
        };

    }

    public int GetDamage(int minDamage, int maxDamage)
    {
        if(Effects["Strength"].active)
        {
            return rand.Next((int)(minDamage * 1.4), (int)(maxDamage * 1.4) + 1);
        }
        else {
        return rand.Next(minDamage, maxDamage + 1);
        }
        
    }

    public abstract bool UseSkill(Enemy enemy);

    public abstract int DealDamage(Enemy enemy);
    


    


    
}