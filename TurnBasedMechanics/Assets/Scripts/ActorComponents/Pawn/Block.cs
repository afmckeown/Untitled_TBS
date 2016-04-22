using UnityEngine;
using System.Collections;
using FullInspector;

public class Block : BaseBehavior
{
    public int Chance { get; set; }
    public int Amount { get; set; }

    public void ModDamage(DamageData damage)
    {
        if (damage.Type != DamageTypes.Direct) return;

        if (Random.Range(0, 100) > Chance) return;

        damage.Amount -= Amount;
        damage.Amount = Mathf.Clamp(damage.Amount, 0, int.MaxValue);
    }

}
