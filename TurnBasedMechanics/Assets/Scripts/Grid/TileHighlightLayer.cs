using System.Collections.Generic;
using FullInspector;
using UnityEngine;

public class TileHighlightLayer : BaseBehavior
{
    private const string PoolKey = "TileHighlightLayer.MoveTileHighlight";
    private const int    PoolPrePopulation = 100;
    private const int    PoolMax = 500;
   
    public GameObject MouseoverHighlightPrefab { get; private set; }
    public GameObject MoveRangeHighlightPrefab { get; private set; }
  
    private Stack<Poolable> ActiveMoveRangeObjects { get; set; }
    
    public void HighlightTile(Point point)
    {
        if (point == null)
        {
            MouseoverHighlightPrefab.SetActive(false);
            return;
        }

        MouseoverHighlightPrefab.transform.position = point.ToWorldPoint();

        if (!MouseoverHighlightPrefab.activeSelf)
        {
            MouseoverHighlightPrefab.SetActive(true);
        }
    }

    public void DisableHighlightTile()
    {
        MouseoverHighlightPrefab.SetActive(false);
    }

    public void ActivateFacingIndicators(Point point)
    {
        var directions = new List<Point>
        {
            point.North(),
            point.South(),
            point.East(),
            point.West()
        };
        ActivateMoveRangeIndicators(directions);
    }

    public void ActivateMoveRangeIndicators(List<Point> points)
    {
        foreach (Point point in points)
        {
            Poolable obj = GameObjectPoolController.Dequeue(PoolKey);
            obj.transform.position = point.ToWorldPoint();
            obj.gameObject.SetActive(true);
            ActiveMoveRangeObjects.Push(obj);
        }
    }

    public void DeactivateMoveRangeIndicators()
    {
        while(ActiveMoveRangeObjects.Count != 0)
        {
            GameObjectPoolController.Enqueue(ActiveMoveRangeObjects.Pop());
        }
    }

    private new void Awake()
    {
        base.Awake();
        ActiveMoveRangeObjects = new Stack<Poolable>();
    }

    private void Start()
    {
        MouseoverHighlightPrefab = Instantiate(MouseoverHighlightPrefab);

        GameObjectPoolController.AddEntry(
            PoolKey,
            MoveRangeHighlightPrefab,
            PoolPrePopulation,
            PoolMax);
    }

} 
    