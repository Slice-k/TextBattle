public abstract class Effect
{

// need to make a check if effect is active, so I can go into damageEffect and change the damage output
// 

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

    public bool IsEffectActive()
    {
        // check effects list if there are any active effects
        // 
        return true;
    }

    public abstract void ApplyEffect();
    public abstract void RemoveEffect();



    
}
