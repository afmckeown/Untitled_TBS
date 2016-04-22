using UnityEngine;
using System.Collections;
using FullInspector;

public class Defenses : BaseBehavior
{
    private Pawn Owner { get;  set; }

    private Armor  Armor  { get { return Owner.Armor;  } }
    private Block  Block  { get { return Owner.Block;  } }
    private Evade  Evade  { get { return Owner.Evade;  } }

    public void ModDamage(DamageData damage)
    {
        Evade.ModDamage(damage);
        Block.ModDamage(damage);
        Armor.ModDamage(damage);
    }

    void Start()
    {
        Owner = GetComponent<Pawn>();

    }
}
