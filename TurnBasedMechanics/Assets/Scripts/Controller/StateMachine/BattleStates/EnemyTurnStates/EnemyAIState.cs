using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Com.LuisPedroFonseca.ProCamera2D;

public class EnemyAIState : EnemyTurnState
{
    private int PawnIndex { get; set; }

    
    public override void Enter()
    {
        base.Enter();
        Debug.Log("EnemyAIState");

        PawnIndex = 0;
        StartCoroutine(RunAI());
    }

    public override void Exit()
    {
        base.Exit();

        var camera = Camera.main.GetComponent<ProCamera2DCinematics>();
        camera.Stop();
        while (camera.CinematicTargets.Count != 0)
            camera.RemoveCinematicTarget(camera.CinematicTargets[0].TargetTransform);
    }

    IEnumerator RunAI()
    {
        var cinema = Camera.main.GetComponent<ProCamera2DCinematics>();

        if (cinema.CinematicTargets.Count != 0)
            Debug.LogError("Cinematic Camera should not already have targets.");

        List<Pawn> pawns = Enemy.Pawns;
        foreach (Pawn pawn in pawns)
        {
            cinema.AddCinematicTarget(pawn.transform);
        }

        cinema.Play();
       
        while (PawnIndex < pawns.Count)
        {
            var pawn = pawns[PawnIndex] as AIPawn;

            BattleController.Instance.ZombieBT.Execute(pawn);
            bool question = pawn.BehaviorState.IsBTRunning;
            Debug.Log("question: " + question);
            while (pawn.BehaviorState.IsBTRunning)
            {
                BattleController.Instance.ZombieBT.Execute(pawn);
                yield return null;
            }
            ++PawnIndex;
          
            cinema.GoToNextTarget();
        }

        Owner.ChangeState<EndEnemyTurnState>();
    }
}

