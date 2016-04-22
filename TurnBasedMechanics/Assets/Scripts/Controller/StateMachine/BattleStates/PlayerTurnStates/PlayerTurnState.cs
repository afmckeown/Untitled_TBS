using UnityEngine;
using System.Collections;

public abstract class PlayerTurnState : BattleState
{
    protected Point MousePoint { get; set; }

    protected override void OnMouseAxis(object sender, object args)
    {
        MousePoint = Board.WorldPointToPoint((Vector2)args);
    }
}
