public class StrengthEffect : Effect
{
    
    public override bool active {get; set;}
    public StrengthEffect(int duration)
    {
        Duration = duration;
    }
    public override void ApplyEffect()
    {
        active = true;
    }
    public override void RemoveEffect()
    {
        active = false;
        Duration = 3;
    }
}