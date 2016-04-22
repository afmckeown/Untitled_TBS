using UnityEngine;
using System.Collections;
using FullInspector;

public class Armor : BaseBehavior
{

    public int Amount { get; private set; }

    public void ModDamage(DamageData damage)
    {
        if (damage.Type == DamageTypes.Internal) return;

        int armor = Amount;
        armor -= damage.ArmorPierce;

        damage.Amount -= armor;
        damage.Amount = Mathf.Clamp(damage.Amount, 0, int.MaxValue);
    }
}
