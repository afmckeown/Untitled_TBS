using System;
using UnityEngine;
using System.Collections;
using FullInspector;
using Random = UnityEngine.Random;

public class Evade : BaseBehavior
{
    public static string EVADE_NOTIFICATION = "EVADE_NOTIFICATION";
    public static string GRAZE_NOTIFICATION = "GRAZE_NOTIFICATION";

    public int Chance { get; set; }

    public void ModDamage(DamageData damage)
    {
        if (damage.Type != DamageTypes.Direct) return;

        int rand = Random.Range(0, 100);

        // Evade?
        if (rand < Chance)
        {
            damage.Amount = 0;
            this.PostNotification(EVADE_NOTIFICATION);
            return;
        }

        Random.seed = Convert.ToInt32(Time.realtimeSinceStartup);
        rand = Random.Range(0, 100);

        // Graze?
        if (rand < Chance/2)
        {
            damage.Amount /= 2;
            this.PostNotification(GRAZE_NOTIFICATION);
            return;
        }
    }
}
