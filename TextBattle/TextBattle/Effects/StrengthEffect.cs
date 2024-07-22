public class StrengthEffect : Effect
{
    
    public string Name {get; }
    public StrengthEffect(string name, int duration)
    {
        Name = name;
        Duration = duration;
    }
    public override void ApplyEffect()
    {
        
    }
    public override void RemoveEffect()
    {

    }
}