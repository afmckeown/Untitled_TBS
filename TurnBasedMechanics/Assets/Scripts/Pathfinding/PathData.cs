using System.Collections.Generic;

public class PathData
{
    public Point Source { get; set; }

    public Dictionary<Point, float> DistanceFromSource { get; set; }

    public Dictionary<Point, Point> PreviousPoint { get; set; }

    public PathData()
    {
        DistanceFromSource = new Dictionary<Point, float>();
        PreviousPoint = new Dictionary<Point, Point>();
    }

    public PathData(Point source)
    {
        Source = source;
        DistanceFromSource = new Dictionary<Point, float>();
        PreviousPoint = new Dictionary<Point, Point>();
    }
}