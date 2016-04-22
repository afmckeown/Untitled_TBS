using System;
using System.Collections.Generic;
using UnityEngine;

public class MovePawnState : PlayerTurnState
{
   
    private List<Point> PointsInRange
    {
        get { return Owner.CurrentPawn.PointsInRange; }
    }
    
    public override void Enter()
    {
        base.Enter();
        Debug.Log("MovePawnState");
        if (PointsInRange.Count == 0)
        {
            Owner.ChangeState<ChoosePawnFacingState>();
            return;
        }

        Board.ActivateMovementTiles(PointsInRange);
        

        //GuiController.Panel.SetActive(true);
        //GuiController.UpdatePawnPanel(CurrentPawn);
    }

    public override void Exit()
    {
        base.Exit();
        Board.DeactivateAllMovementTiles();
       // GuiController.Panel.SetActive(false);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        InspectPoint(MousePoint);
    }

    protected override void OnFire(object sender, object args)
    {
        if (Selected == null) return;
       
        if (PointsInRange.Contains(Selected))
            Owner.ChangeState<MoveSequenceState>();
        else
            Owner.ChangeState<SelectPawnState>();
    }

    protected virtual void InspectPoint(Point point)
    {
        Selected = point;
        Board.SetInspectedIndicator(Selected);
    }
}
