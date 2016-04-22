using System.Collections.Generic;
using System.Linq;
using FullInspector;
using UnityEngine;

public class Movement : BaseBehavior
{
    public const string DONE_MOVING = "DONE_MOVING";

    [SerializeField] private float _moveSpeed;

    [SerializeField] private int _range;

    private PointPosition PointPosition { get; set;}

    public Point Position
    {
        get { return PointPosition.Point; }
        set { PointPosition.Point = value; }
    }

    private bool PathfindingOutOfDate { get; set; }

    private PathingGraph PathfindingGraph
    {
        get { return BattleController.Instance.Board.PathingGraph; }
    }

    private DeathEvent _deathEvent;
   
    private PathData _pathData;
    private List<Point> _pointsInRange;

    private Dictionary<Point, float> Distances
    {
        get { return _pathData.DistanceFromSource; }
        set { _pathData.DistanceFromSource = value; }
    }

    private Dictionary<Point, Point> Paths
    {
        get { return _pathData.PreviousPoint; }
        set { _pathData.PreviousPoint = value; }
    }

    public List<Point> PointsInRange
    {
        get
        {
            UpdatePathingData();
            return _pointsInRange;
        }
        private set { _pointsInRange = value; }
    }

    public bool IsMoving { get; private set; }
    
    private Stack<Point> Path { get; set; }
    private Point Previous { get; set; }
    private Vector3 Dest { get; set; }
    
    public int Range
    {
        get { return _range; }
        private set { _range = value; }

    }
    private Transform Transform { get; set; }
    
    private float MoveSpeed
    {
        get { return _moveSpeed; }
        set { _moveSpeed = value; }
    }

    public bool Move(Point destination)
    {
        UpdatePathingData();
        if (!Distances.ContainsKey(destination)) return false;
        if (Path.Count != 0) return false;

        IsMoving = true;

        Point prev = destination;
        Path.Push(destination);
        while (Paths[prev] != Position)
        {
            Path.Push(Paths[prev]);
            prev = Paths[prev];
        }

        Directions CardDirection = Position.GetDirection(Path.Peek());
        _deathEvent.OnFacingChanged(CardDirection);
        Previous = Path.Peek();
        Dest = Path.Pop().ToWorldPoint();

        this.PostNotification(Notifications.ACTOR_LEFT_POINT, Position);

        Position = destination;

        this.PostNotification(Notifications.ACTOR_ENTERED_POINT, Position);

        return true;
    }

    private void MoveTowardsDest()
    {
        if (!IsMoving) return;
        Vector3 pos = Transform.position;

        Vector3 direction = Dest - pos;
        direction.Normalize();

        Transform.Translate(direction * MoveSpeed * Time.deltaTime);

        // if were not done moving towards the next tile, return
        if (Vector3.Distance(pos, Dest) > 0.1f) return;
        
        // If we have not reached the final tile, set destination to next tile
        if (Path.Count != 0)
        {
            
            Directions cardDirection = Previous.GetDirection(Path.Peek());
            _deathEvent.OnFacingChanged(cardDirection);
            Previous = Path.Peek();
            Dest = Path.Pop().ToWorldPoint();
            return;
        }

        IsMoving = false;
        Transform.position = Dest;
        this.PostNotification(DONE_MOVING);

    }

    private void BoardChanged()
    {
        // Running pathfinding immediately after board change
        // is less noticeable than when a Pawn is selected
        // because player should thinking about next move
        //GeneratePointsInRange();
    }

    public void UpdatePathingData()
    {
        if (PathfindingOutOfDate == false) return;

        _pathData = PathFinding.Dijkstra(PathfindingGraph, Position, Range);
        
        PointsInRange = Distances.Keys.Where(point => point != Position).ToList();

        PathfindingOutOfDate = false;
    }

    //public void GeneratePointsInRange()
    //{
    //    //float time = Time.realtimeSinceStartup;

    //    switch (MoveType)
    //    {
    //        case MovementType.Free:
    //            _pathData = 
    //                PathFinding.Dijkstra(
    //                    BoardPosition.PointPosition,
    //                    Range,
    //                    true);
    //            break;
    //        case MovementType.FreeNoDiagonals:
    //            _pathData = 
    //                PathFinding.Dijkstra(
    //                    BoardPosition.PointPosition,
    //                    Range);
    //            break;
    //        default:
    //            Debug.LogError(
    //                "Unexpected default case triggered. MovementType not handled.");
    //            break;
    //    }

    //    PointsInRange = Distances.Keys.ToList();

    //    //Debug.Log("GenCellInRange: " + (Time.realtimeSinceStartup - time));

    //}

    public void OnActorLeftPoint(object sender, object args)
    {
        PathfindingOutOfDate = true;
    }

    public void OnActorEnteredPoint(object sender, object args)
    {
        PathfindingOutOfDate = true;
    }

    private void OnEnable()
    {
        this.AddObserver(OnActorLeftPoint, Notifications.ACTOR_ENTERED_POINT);
        this.AddObserver(OnActorEnteredPoint, Notifications.ACTOR_LEFT_POINT);
    }

    private new void Awake()
    {
        base.Awake();
        _pathData = new PathData();
        Path = new Stack<Point>();

        PathfindingOutOfDate = true;
    }

    // Use this for initialization
    private void Start()
    {
        Transform = gameObject.transform;
        PointPosition = GetComponent<PointPosition>();
        _deathEvent = GetComponent<DeathEvent>();

        //PointSelectedEvent.BoardChanged += BoardChanged;

        //GeneratePointsInRange();
    }

    // Update is called once per frame
    private void Update()
    {
        if (IsMoving) MoveTowardsDest();
    }
}