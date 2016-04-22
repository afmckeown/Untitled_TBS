//using UnityEngine;
//using System.Collections;

//public class Dot : Condition
//{
//    private Pawn Target { get; set; }

//    private DamageData Damage { get; set; }

//    private int Frequency { get; set; }

//    private int Duration { get; set; }

//    private int TurnsElapsed { get; set; }

//    public override void OnApply(Pawn target)
//    {
//        base.OnApply(target);
//        Target = target;
//        this.AddObserver(OnTurnStart, Notifications.PLAYER_TURN_ENTER);
//        this.AddObserver(OnTurnStart, Notifications.ENEMY_TURN_ENTER);
//    }

//    public void OnTurnStart(object sender, object args)
//    {
//        ++TurnsElapsed;
//        if(TurnsElapsed % Frequency == 0)
//            Target.TakeDamage(Damage);
//        if (TurnsElapsed == Duration) Remove();
//    }

//}
