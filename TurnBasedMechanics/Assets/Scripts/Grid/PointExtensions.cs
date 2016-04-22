using System;
using System.Collections.Generic;
using UnityEngine;

public static class PointExtensions
{
    public static Point ToPoint(this Vector2 worldPoint)
    {
        int x = (int)((worldPoint.x) + 0.5f);
        int y = (int)((worldPoint.y) + 0.5f);

        var point = new Point(x, y);
        
        return point;
    }

    public static Vector2 ToWorldPoint(this Point point)
    {
        float xWorld = point.X;
        float yWorld = point.Y;

        return new Vector2(xWorld, yWorld);
    }

    public static Point Cardinal(this Point source, Directions direction, int distance = 1)
    {
        switch (direction)
        {
            case Directions.North:
                return source.North(distance);
            case Directions.East:
                return source.East(distance); ;
            case Directions.South:
                return source.South(distance); ;
            case Directions.West:
                return source.West(distance); ;
            default:
                throw new ArgumentOutOfRangeException("direction", direction, null);
        }
    }

    public static List<Point> Adjacent(this Point source)
    {
        return new List<Point>()
        {
            source.North(),
            source.East(),
            source.South(),
            source.West()
        };
    } 

    public static Point North(this Point source, int distance = 1)
    {
        return new Point(source.X, source.Y + distance);
    }

    public static Point South(this Point source, int distance = 1)
    {
        return new Point(source.X, source.Y - distance);
    }

    public static Point East(this Point source, int distance = 1)
    {
        return new Point(source.X + distance, source.Y);
    }

    public static Point West(this Point source, int distance = 1)
    {
        return new Point(source.X - distance, source.Y);
    }

    public static Point NorthEast(this Point source, int distance = 1)
    {
        return new Point(source.X + distance, source.Y + distance);
    }

    public static Point NorthWest(this Point source, int distance = 1)
    {
        return new Point(source.X - distance, source.Y + distance);
    }

    public static Point SouthEast(this Point source, int distance = 1)
    {
        return new Point(source.X + distance, source.Y - distance);
    }

    public static Point SouthWest(this Point source, int distance = 1)
    {
        return new Point(source.X - distance, source.Y - distance);
    }

    public static List<Point> Neighbors(this Point source)
    {
        return new List<Point> {source.North(), source.South(), source.East(), source.West()};
    }

    public static List<Point> DiagonalNeighbors(this Point source)
    {
        var neighbors = new List<Point>();

        Point northEast = source + new Point(1, 1);
        Point northWest = source + new Point(1, -1);
        Point southEast = source + new Point(-1, 1);
        Point southWest = source + new Point(-1, -1);

        neighbors.Add(northEast);
        neighbors.Add(northWest);
        neighbors.Add(southEast);
        neighbors.Add(southWest);

        return neighbors;
    }

    public static List<Point> NeighborsWithDiagonal(this Point source)
    {
        List<Point> neighbors = Neighbors(source);

        neighbors.AddRange(DiagonalNeighbors(source));

        return neighbors;
    }

    public static int Distance(this Point source, Point dest)
    {
        int xDist = Math.Abs(dest.X - source.X);
        int yDist = Math.Abs(dest.Y - source.Y);

        return xDist + yDist;
    }
}