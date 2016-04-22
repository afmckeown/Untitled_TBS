using FullInspector;
using UnityEngine;

public class Health : BaseBehavior
{
    public int Max { get; private set; }

    public int Remaining { get; private set; }
    

    public void TakeDamage(int damage)
    {
        // No healing with this method
        if (damage <= 0) return;

        // Damage is lethal
        if (damage >= Remaining)
        {
            Remaining = 0;
          
            return;
        }

        Remaining -= damage;
    }

    private new void Awake()
    {
        base.Awake();
        
        Remaining = Max;
    }
}