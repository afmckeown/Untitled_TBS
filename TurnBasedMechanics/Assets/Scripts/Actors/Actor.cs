using FullInspector;
using UnityEngine;

public class Actor : BaseBehavior
{
    public string Name { get; private set; }

    private PointPosition PointPosition { get; set; }

    public Point Position
    {
        get { return PointPosition.Point; }
    }

    protected Transform Transform { get; set; }

    public Vector2 WorldPosition
    {
        get { return Transform.position; }
        set { Transform.position = Board.AdjustWorldPoint(value); }
    }

    //public BoardPosition BoardPosition { get; private set; }

    
    //public PointPosition PointPosition
    //{
    //    get { return BoardPosition.PointPosition; }
    //    protected set { BoardPosition.PointPosition = value; }
    //}

    protected void InitAwake()
    {
        Transform = gameObject.transform;
        WorldPosition = Transform.position;
        PointPosition = GetComponent<PointPosition>();
    }

    
    private new void Awake()
    {
        base.Awake();
        InitAwake();
    }
   

    private void Start()
    {
        
    }

    private void Update() {}
}