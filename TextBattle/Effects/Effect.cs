public abstract class Effect
{

    public int Duration { get; set; }


    public void Tick()
    {
        if (Duration > 0)
        {
            Duration--;
            if (Duration == 0)
            {
                RemoveEffect();
            }
        }

    }

    public abstract void ApplyEffect();
    public abstract void RemoveEffect();



    
}
