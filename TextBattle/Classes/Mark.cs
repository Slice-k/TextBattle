public class Mark : Player
{

public Mark()
{
    Name = "Big Brolic 6'3 NiGGa";
    MaxHP = 500;
    CurrentHP = MaxHP;
}

    public override int DealDamage(Enemy enemy)
    {
        int damage = GetDamage(1, 10);
        enemy.CurrentHP -= damage;
        return damage;
    }

    public override bool UseSkill(Enemy enemy)
    {
        throw new NotImplementedException();
    }

}