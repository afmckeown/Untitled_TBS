using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChoosePawnFacingState : PlayerTurnState
{
    private List<Point> FacingOptions { get; set; }
    private Point Position { get; set; }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("ChoosePawnFacingState");


        Position = CurrentPawn.Position;
        FacingOptions = Position.Adjacent();
       
        Board.ActivateMovementTiles(FacingOptions);
    }

    public override void Exit()
    {
        base.Exit();
        Board.DeactivateAllMovementTiles();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        InspectPoint(MousePoint);
    }


    protected virtual void InspectPoint(Point point)
    {
        Selected = point;
        Board.SetInspectedIndicator(Selected);
    }

    protected override void OnFire(object sender, object args)
    {
        if (Selected == null) return;

        if (FacingOptions.Contains(Selected))
        {
            CurrentPawn.FacingAfterMove = Position.GetDirection(Selected);
        }
            
       
        Owner.ChangeState<SelectPawnState>();
    }

    //protected override void OnTouch(object sender, object args)
    //{
    //    Point point = Board.WorldPointToPoint((Vector2)args);
    //    InspectPoint(point);

    //    if (CurrentPawn != null)
    //    {
    //        Owner.ChangeState<MovePawnState>();
    //    }
    //}
}