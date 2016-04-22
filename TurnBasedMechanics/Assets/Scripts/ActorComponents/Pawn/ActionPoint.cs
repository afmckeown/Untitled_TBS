using System;
using FullInspector;
using UnityEngine;

[Serializable]
public class ActionPoint : BaseBehavior
{
    public int Max { get; set; }

   public int PointsRemaining { get; set; }

    public bool Use(int actionPointsUsed, bool allowOverSpending = false)
    {
        if (actionPointsUsed > PointsRemaining && !allowOverSpending)
            return false;

        PointsRemaining -= actionPointsUsed;

        return true;
    }

    public void Fill()
    {
        PointsRemaining = Max;
    }

    public new void Awake()
    {
        base.Awake();
        Fill();
    }
}