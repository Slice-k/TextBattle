public class DamageEffect
{
    private Random rand = new Random();
    private int minDamage;
    private int maxDamage;
    private int strengthBonus;

    public DamageEffect(int minDamage, int maxDamage, int strengthBonus = 7)
    {
        this.minDamage = minDamage;
        this.maxDamage = maxDamage;
        this.strengthBonus = strengthBonus;
    }

    public int CalculateDamage()
    {
        return rand.Next(minDamage, maxDamage + 1);
        
    }
}
