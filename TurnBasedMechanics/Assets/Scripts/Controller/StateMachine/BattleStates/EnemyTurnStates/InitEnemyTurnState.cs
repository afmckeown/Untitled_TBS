using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Behavior_Tree;
using Com.LuisPedroFonseca.ProCamera2D;


public class InitEnemyTurnState : EnemyTurnState
{
    public bool AIDone { get; set; }  

    private int Index { get; set; }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("InitEnemyTurnState");
        this.PostNotification(Notifications.ENEMY_TURN_ENTER);
        Init();
    }

    public override void Exit()
    {
        base.Exit();

        

        //var camera = Camera.main.GetComponent<ProCamera2D>();


        //if (camera.CameraTargets.Count != 0)
        //camera.RemoveCameraTarget(camera.CameraTargets[0].TargetTransform);
    }

    // Cant change state during Enter() so coroutine delays a frame
    // before changing state
    void Init()
    {
        Index = 0;
        AIDone = false;
        Enemy.RefreshPawns();
        Enemy.UpdatePathfinding(PathingGraph);


        

        Owner.ChangeState<EngageEnemyTurnState>();


    }
    
}
