using System;
using UnityEngine;
using System.Collections;

public class SelectPawnState : PlayerTurnState
{
   public override void Enter()
    {
        base.Enter();
        Debug.Log("SPS");
        CurrentPawn = null;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        InspectPoint(MousePoint);
    }

    protected virtual void InspectPoint(Point point)
    {
        if (Selected == point) return;
        Selected = point;
        // TODO: make better :/
        if (Player.IsPawnOnPoint(point))
        {
            Debug.Log("Pawn on point");
            CurrentPawn = Player.GetPawnOnPoint(point);
            //GuiController.Panel.SetActive(true);
           // GuiController.UpdatePawnPanel(CurrentPawn);
        }
        else
        {
            CurrentPawn = null;
           // GuiController.Panel.SetActive(false);
        }

        Board.SetInspectedIndicator(Selected);
    }

    protected override void OnFire(object sender, object args)
    {
        base.OnFire(sender, args);

        int fireOption = (int) args;

        if (fireOption == 0 && CurrentPawn != null)
        {
            Owner.ChangeState<MovePawnState>();
        }
        else if (fireOption == 1)
        {
            Owner.ChangeState<EndPlayerTurnState>();
        }

    }

    protected override void OnTouch(object sender, object args)
    {
        Point point = Board.WorldPointToPoint((Vector2)args);
        InspectPoint(point);

        if (CurrentPawn != null)
        {
            Owner.ChangeState<MovePawnState>();
        }
    }
}
