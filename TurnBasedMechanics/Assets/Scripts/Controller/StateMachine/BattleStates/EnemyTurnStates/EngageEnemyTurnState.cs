using UnityEngine;
using System.Collections;

public class EngageEnemyTurnState : EnemyTurnState
{
    public override void Enter()
    {
        base.Enter();

        foreach (Pawn pawn in Enemy.Pawns)
        {
            if (Player.IsPawnOnPoint(pawn.Engage))
                Player.GetPawnOnPoint(pawn.Engage).TakeDamage(pawn.Attack());
        }

        Owner.ChangeState<EnemyAIState>();
    }
	
}
