using System;
using UnityEngine;

public abstract class BattleState : State
{
    protected BattleController Owner { get; set; }

    public Player Player  { get { return Owner.Player; } }

    public Player Enemy   { get { return Owner.Enemy; } }

    public Player Neutral { get { return Owner.Neutral; } }

    public Board Board { get { return Owner.Board; } }

    //public AbilityMenuPanelController AbilityMenuPanelController
    //{
    //    get { return Owner.AbilityMenuPanelController; }
    //}


    //public MyGui GuiController { get { return owner.GuiController; } }

    public Pawn CurrentPawn
    {
        get { return Owner.CurrentPawn; }
        protected set { Owner.CurrentPawn = value; }
    }

    public PathingGraph PathingGraph { get { return Board.PathingGraph; } }

    public Point Selected
    {
        get { return Owner.Selected; }
        set { Owner.Selected = value; }
    }

    protected new virtual void Awake()
    {
        base.Awake();
        Owner = GetComponent<BattleController>();
    }

    protected override void AddListeners()
    {
        this.AddObserver(OnMove, Notifications.MOVE);
        this.AddObserver(OnMouseAxis, Notifications.MOUSE_MOVED);
        this.AddObserver(OnFire, Notifications.FIRE);

        this.AddObserver(OnTouch, "Touch");
    }

    protected override void RemoveListeners()
    {
        this.RemoveObserver(OnMove, Notifications.MOVE);
        this.RemoveObserver(OnMouseAxis, Notifications.MOUSE_MOVED);
        this.RemoveObserver(OnFire, Notifications.FIRE);

        this.RemoveObserver(OnTouch, "Touch");
    }

    protected virtual void OnMove(object sender, object args) { }

    protected virtual void OnMouseAxis(object sender, object args) {}
   
    protected virtual void OnFire(object sender, object args) {}

    protected virtual void OnTouch(object sender, object args) {}

    protected virtual void SelectPoint(Point selected)
    {
        if ( Selected == selected || !Board.IsInBounds(selected))
            return;

        Selected = selected;
    }
}
