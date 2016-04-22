using System;
using UnityEngine;

public static class Direction
{
    public enum Cardinal
    {
        North = 0,
        East = 270,
        South = 180,
        West = 90,
        NorthEast = 315,
        NorthWest = 45,
        SouthEast = 225,
        SouthWest = 135,
        None = int.MinValue

    }

    public static Vector3 GetRotation(float zRotation)
    {
        return new Vector3(0, 0, zRotation);
    }

    public static Vector3 GetRotation(Cardinal direction)
    {
        return new Vector3(0,0, (float) direction);
    }
}