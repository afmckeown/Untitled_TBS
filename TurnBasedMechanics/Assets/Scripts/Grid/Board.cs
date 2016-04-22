using System.Collections.Generic;
using UnityEngine;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using System.IO;
using FullInspector;

public class Board : BaseBehavior
{
    private const float boardOffsetX = 0.5f;
    private const float boardOffsetY = 0.5f;

    [SerializeField]
    public int Height { get; private set; }

    [SerializeField]
    public int Width { get; private set; }

    [SerializeField]
    public float TileSize { get; set; }

    [SerializeField]
    private TileHighlightLayer TileHighlightLayer { get; set; }

    public PathingGraph PathingGraph { get; private set; }  
   
    public static Vector2 AdjustWorldPoint(Vector2 worldPoint)
    {
        int x = (int)((worldPoint.x) + boardOffsetX);
        int y = (int)((worldPoint.y) + boardOffsetY);

        return new Vector2(x, y);
    }

    public void SetInspectedIndicator(Point point)
    {
        if(point != null)
            TileHighlightLayer.HighlightTile(point);
        else
            TileHighlightLayer.DisableHighlightTile();
    }

    public void ActivateFacingIndicators(Point point)
    {
        TileHighlightLayer.ActivateFacingIndicators(point);
    }

    public void ActivateMovementTiles(List<Point> points)
    {
        TileHighlightLayer.ActivateMoveRangeIndicators(points);
    }

    public void DeactivateAllMovementTiles()
    {
        TileHighlightLayer.DeactivateMoveRangeIndicators();
    }

    public void Load()
    {
        var deserializer = new Deserializer();
        var readStream = new StreamReader("Assets/Resources/Test.txt");
        var configBoardData = deserializer.Deserialize<BoardData>(readStream);

        if (Height != configBoardData.BoardHeight)
        {
            Debug.LogWarning(
                "PointExtensions Size does not match Board Size \n" +
                "PointExtensions.Height = " + Height + "; Board Height = " + configBoardData.BoardHeight);
        }
        if (Width != configBoardData.BoardWidth)
        {
            Debug.LogWarning(
                "PointExtensions Size does not match Board Size \n" +
                "PointExtensions.Width = " + Width + "; Board Width = " + configBoardData.BoardWidth);
        }
       
        foreach (XY xy in configBoardData.BlockingPoints)
        {
            Point point = new Point(xy.X, xy.Y).South(2).West(2);

            if(IsInBounds(point))
                PathingGraph.DisconnectFromAll(point);
        }
    }

    public Direction.Cardinal GetDirection(Point source, Point neighbor)
    {
        if (!IsNeighbor(source, neighbor)) return Direction.Cardinal.None;

        Point direction = GetPointDirectionNormalized(source, neighbor);

        return NormalizedPointToDirection(direction);
    }

    private static Direction.Cardinal NormalizedPointToDirection(Point normalized)
    {
        int x = normalized.X;
        int y = normalized.Y;

        // Ensure PointPosition is normalized
        if (Mathf.Abs(x) > 1) return Direction.Cardinal.None;
        if (Mathf.Abs(y) > 1) return Direction.Cardinal.None;

        if (x == 0  && y == 1)  return Direction.Cardinal.North;
        if (x == 0  && y == -1) return Direction.Cardinal.South;
        if (x == 1  && y == 0)  return Direction.Cardinal.East;
        if (x == -1 && y == 0)  return Direction.Cardinal.West;
        if (x == 1  && y == 1)  return Direction.Cardinal.NorthEast;
        if (x == -1 && y == 1)  return Direction.Cardinal.NorthWest;
        if (x == 1  && y == -1) return Direction.Cardinal.SouthEast;
        if (x == -1 && y == -1) return Direction.Cardinal.SouthWest;

        return Direction.Cardinal.None;
    }

    private Point GetPointDirectionNormalized(Point source, Point neighbor)
    {
        int xDiff = neighbor.X - source.X;
        int yDiff = neighbor.Y - source.Y;
        if(xDiff != 0)
            xDiff = xDiff < 0 ? -1 : 1;
        if(yDiff != 0)
            yDiff = yDiff < 0 ? -1 : 1;

        return new Point(xDiff, yDiff);
    }

    public bool IsNeighbor(Point source, Point neighbor, bool diagonalCounts = true)
    {
        if (!IsInBounds(source)) return false;
        if (!IsInBounds(neighbor)) return false;

        int xDiff = Mathf.Abs(neighbor.X - source.X);
        int yDiff = Mathf.Abs(neighbor.Y - source.Y);

        if (xDiff > 1) return false;
        if (yDiff > 1) return false;

        if (diagonalCounts) return true;

        // return false if neighbor is diagonal 
        return xDiff != 1 || yDiff != 1;
    }

    public Point WorldPointToPoint(Vector2 worldPoint)
    {
        Point point = worldPoint.ToPoint();

        if (!IsInBounds(point)) return null;
            //Debug.LogError("Attempting to access Board PointPosition that is out-of-bounds.");

        return point;

    }

    public Vector2 PointToWorldPoint(Point point)
    {
        if (!IsInBounds(point))
            Debug.LogError("Attempting to access Board PointPosition that is out-of-bounds.");

        return point.ToWorldPoint();
    }

    public bool IsInBounds(Point point)
    {
        return IsInBounds(point.X, point.Y);
    }

    public bool IsInBounds(int x, int y)
    {
        if (x < 0) return false;
        if (y < 0) return false;

        if (x >= Width) return false;
        if (y >= Height) return false;

        return true;
    }


    private new void Awake()
    {
        base.Awake();
        PathingGraph = new PathingGraph(Height, Width);
    }
}