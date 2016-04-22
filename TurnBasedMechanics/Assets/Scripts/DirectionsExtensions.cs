using UnityEngine;
using System.Collections;

public static class DirectionsExtensions
{
    public static Directions GetDirection(this Point t1, Point t2)
    {
        int x;
        int y;

        // Normalize
        if (t1.X == t2.X) x = 0;
        else x = t1.X < t2.X ? 1 : -1;

        if (t1.Y == t2.Y) y = 0;
        else y = t1.Y < t2.Y ? 1 : -1;

        if (x == 0  &&  y == 1)  return Directions.North;
        if (x == 0  &&  y == -1) return Directions.South;
        if (x == 1  &&  y == 0)  return Directions.East;
        if (x == -1 &&  y == 0)  return Directions.West;
        if (x == 1  &&  y == 1)  return Directions.NorthEast;
        if (x == -1 &&  y == 1)  return Directions.NorthWest;
        if (x == 1  &&  y == -1) return Directions.SouthEast;
        if (x == -1 &&  y == -1) return Directions.SouthWest;

        return Directions.None;
    }

    public static Vector3 ToEuler(this Directions d)
    {
        return new Vector3(0, 0, (float)d);
    }
}
