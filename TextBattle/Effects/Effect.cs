public class Effect
{

    public int Duration { get; set; }

    public void Tick()
    {
        if (Duration > 0)
        {
            Duration--;
            if (Duration == 0)
            {
                Console.WriteLine("=== Your {0} has ran out ===");
                RemoveEffect();
            }
        }

    }



    public void ApplyEffect()
    {
       
    }
    public void RemoveEffect()
    {
        
    }



    
}
