using UnityEngine;
using System.Collections;

public class MoveSequenceState : PlayerTurnState
{
    public override void Enter()
    {
        base.Enter();

        //GuiController.Panel.SetActive(true);

        CurrentPawn.Move(Selected);
        Owner.ChangeState<ChoosePawnFacingState>();
    }

    public override void Exit()
    {
        base.Exit();

        //GuiController.Panel.SetActive(false);
    }
}
