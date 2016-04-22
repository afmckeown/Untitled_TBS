
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathingGraph
{
    private Node[,] Graph { get; set; }
    private int Height { get; set; }
    private int Width { get; set; }

    public bool OriginIsWalkableDebug()
    {
        return Graph[0,0].Connected;
    }

    public float Cost(Point point)
    {
        return PointToNode(point).Cost;
    }

    private Node PointToNode(Point point)
    {
        Point adjPoint = point.NorthEast();
        if (adjPoint.X > Width)  return null;//Debug.LogError("Access Error, node not in graph");
        if (adjPoint.Y > Height) return null;//Debug.LogError("Access Error, node not in graph");
        return Graph[adjPoint.X, adjPoint.Y];
    }

    public void DisconnectFromAll(Point point)
    {
        PointToNode(point).Connected = false;
    }

    public void ConnectToNeighbors(Point point)
    {
        PointToNode(point).Connected = true;
    }

    private bool IsWalkable(Point point)
    {
        return PointToNode(point).Connected;
    }

    public List<Point> ConnectedNodes(Point source)
    {
        var neighbors = new List<Point>();

        Point north = source.North();
        Point south = source.South();
        Point east = source.East();
        Point west = source.West();

        if (IsWalkable(north))
            neighbors.Add(north);
        if (IsWalkable(south))
            neighbors.Add(south);
        if (IsWalkable(east))
            neighbors.Add(east);
        if (IsWalkable(west))
            neighbors.Add(west);

        return neighbors;
    }

    // Point no longer occupied by an Actor, therefore reconnect
    // to neighbors
    public void OnActorLeftPoint(object sender, object args)
    {
        ConnectToNeighbors(args as Point);
    }

    // Point now occupied by Actor, therefore disconnect
    // from neighbors
    public void OnActorEnteredPoint(object sender, object args)
    {
        DisconnectFromAll(args as Point);
    }

    public PathingGraph(int height, int width)
    {
        // Create a 1 node unwalkable border around graph
        // This helps prevent fuck-ups
        Height = height + 2;
        Width  = width + 2;

        Graph = new Node[Width, Height];

        // Generate Nodes, set the border as unpathable
        for(int x = 0; x < Width; ++x)
            for(int y = 0; y < Height; ++y)
            {
                Graph[x,y] = new Node();

                bool isEdgeNode = 
                        (x == 0) || (y == 0) || (x == Width - 1) || (y == Height - 1);

                if (isEdgeNode) Graph[x, y].Connected = false;
            }

        this.AddObserver(OnActorLeftPoint, Notifications.ACTOR_LEFT_POINT);
        this.AddObserver(OnActorEnteredPoint, Notifications.ACTOR_ENTERED_POINT);
    }

    ~PathingGraph()
    {
        this.RemoveObserver(OnActorLeftPoint, Notifications.ACTOR_LEFT_POINT);
        this.RemoveObserver(OnActorEnteredPoint, Notifications.ACTOR_ENTERED_POINT);
    }

}
