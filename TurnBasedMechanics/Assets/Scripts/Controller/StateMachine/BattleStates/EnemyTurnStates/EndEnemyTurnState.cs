using UnityEngine;
using System.Collections;

public class EndEnemyTurnState : EnemyTurnState
{
    public override void Enter()
    {
        base.Enter();
        Debug.Log("EndEnemyTurnState");
        this.PostNotification(Notifications.END_TURN);
        this.PostNotification(Notifications.ENEMY_TURN_EXIT);
        Owner.ChangeState<InitPlayerTurnState>();
    }
}
