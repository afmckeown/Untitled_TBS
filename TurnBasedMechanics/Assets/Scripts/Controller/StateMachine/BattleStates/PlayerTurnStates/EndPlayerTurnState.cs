using UnityEngine;
using System.Collections;

public class EndPlayerTurnState : PlayerTurnState
{
    public override void Enter()
    {
        base.Enter();
        Debug.Log("EndPlayerTurnState");
        this.PostNotification(Notifications.END_TURN);
        this.PostNotification(Notifications.PLAYER_TURN_EXIT);
        Owner.ChangeState<InitEnemyTurnState>();
    }
}
