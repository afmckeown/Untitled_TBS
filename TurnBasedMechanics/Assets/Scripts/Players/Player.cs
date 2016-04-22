using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FullInspector;
using UnityEngine;

public class Player : BaseBehavior
{
    public int TestPlayerSpawnX { get; set; }
    public int TestPlayerSpawnY { get; set; }

    public GameObject PawnPrefab { get; private set; }

    
    public List<Pawn> Pawns { get; private set; }

    [HideInInspector]
    public List<Actor> Actors { get; private set; }

    public Allegiances Allegiance { get; private set; }

    public void RefreshPawns()
    {
        foreach (Pawn pawn in Pawns)
        {
            pawn.Refresh();
        }
    }

    public void UpdatePathfinding(PathingGraph graph)
    {
        foreach (Pawn pawn in Pawns)
        {
            pawn.UpdatePathingData();
        }
    }

    public void UpdatePathfinding()
    {
        foreach (Pawn pawn in Pawns)
        {
            pawn.UpdatePathingData();
        }
    }

    public bool IsPawnOnPoint(Point point)
    {
        return Pawns.Any(pawn => point == pawn.Position);
    }

    public bool IsActorOnPoint(Point point)
    {
        return IsPawnOnPoint(point) ||
               Actors.Any(actor => point == actor.Position);
    }

    public Pawn GetPawnOnPoint(Point point)
    {
        return Pawns.FirstOrDefault(pawn => point == pawn.Position);
    }

    public List<Point> GetOccupiedPoints()
    {
        List<Point> occupiedPoints =
            Actors.Select(actor => actor.Position).ToList();

        occupiedPoints.AddRange(Pawns.Select(pawn => pawn.Position));

        return occupiedPoints;
    }

    private new void Awake()
    {
        base.Awake();

        if (Pawns != null && Pawns.Count != 0) return;

        Pawns = new List<Pawn>();

        for (int i = 0; i < TestPlayerSpawnX; ++i)
        {
            for (int j = 0; j < TestPlayerSpawnY; ++j)
            {
                if (PawnPrefab == null) continue;

                GameObject prefab = Instantiate(PawnPrefab);
                prefab.transform.SetParent(transform, true);
                prefab.transform.position = new Vector3(i*2, j*2, 0);
                Pawns.Add(prefab.GetComponent<Pawn>());
            }
        }
    }

    public void Start()
    {
        if (Pawns == null)
        {
            Debug.LogError(Allegiance.ToString() + " has no units.");
            return;
        }
        if (Pawns.Contains(null))
        {
            Debug.LogError(Allegiance.ToString() + " has at least one null unit.");
            return;
        }

        foreach (Pawn pawn in Pawns)
        {
            pawn.Allegiance = Allegiance;
            this.PostNotification(Notifications.ACTOR_ENTERED_POINT, pawn.Position);
        }
    }
}