using UnityEngine;
using System.Collections;
using FullInspector;

public class PointPosition : BaseBehavior
{
    public Point Point { get; set; }

    public int X
    {
        get { return Point.X; }
        set { Point = new Point(value, Point.Y); }
    }

    public int Y
    {
        get { return Point.Y; }
        set { Point = new Point(Point.X, value); }
    }

    protected override void Awake()
    {
        base.Awake();
        Vector2 worldPos 
            = Board.AdjustWorldPoint(GetComponent<Transform>().position);

        Point = new Point((int)worldPos.x, (int)worldPos.y);
    }
}
