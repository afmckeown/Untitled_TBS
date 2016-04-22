using System.Collections;
using UnityEngine;

public class InitBattleState : BattleState
{
    public override void Enter()
    {
        base.Enter();
        Init();
    }

    // Cant change state during Enter() so coroutine delays a frame
    // before changing state
    private void Init()
    {
        Board.Load();

        foreach (Pawn pawn in Player.Pawns)
        {
            PathingGraph.DisconnectFromAll(pawn.Position);
        }

        foreach (Pawn pawn in Enemy.Pawns)
        {
            PathingGraph.DisconnectFromAll(pawn.Position);
        }
       
        if (Owner.SkipConversation)
        {
            Owner.ChangeState<InitPlayerTurnState>();
        }
        else
        {
            Owner.ChangeState<CutSceneState>();
        }
    }


}