using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FullInspector;

public class BehaviorState : BaseBehavior
{
    public Point MoveSelection { get; set; }

    public Directions FacingSelection { get; set; }

    public List<Point> PointOptions { get; set; } 

    public Point PointChoice { get; set; }

    public bool IsBTRunning { get; set; }

    protected override void Awake()
    {
        base.Awake();

        IsBTRunning = false;
    }
	
}
