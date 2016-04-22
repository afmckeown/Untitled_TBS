using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Point : IEquatable<Point>
{
    public int X { get; set; }

    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    //TODO: wtf happens when this is removed :/
    public Point()
    {
        X = 0;
        Y = 0;
    }

    public static Point operator +(Point a, Point b)
    {
        return new Point(a.X + b.X, a.Y + b.Y);
    }

    public static Point operator -(Point p1, Point p2)
    {
        return new Point(p1.X - p2.X, p1.Y - p2.Y);
    }


    public override string ToString()
    {
        return string.Format("PointPosition(X: {0}, Y: {1})", X, Y);
    }

    // Resharper Generated Comparison and Hash Methods
    // Allows PointPosition to be used as a Hash Key for direct lookups

    public bool Equals(Point other)
    {
        return X == other.X && Y == other.Y;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Point) obj);
    }

    // Override == and != to be a value check, instead of a 
    // reference check. 2 points with the same XY should be 
    // considered the same PointPosition in all cases.

    public static bool operator ==(Point left, Point right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Point left, Point right)
    {
        return !Equals(left, right);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return (X*397) ^ Y;
        }
    }
}