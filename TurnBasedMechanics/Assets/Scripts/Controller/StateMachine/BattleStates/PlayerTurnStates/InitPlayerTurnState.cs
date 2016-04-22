using UnityEngine;
using System.Collections;
using Com.LuisPedroFonseca.ProCamera2D;
//TbsGit9*
public class InitPlayerTurnState : PlayerTurnState
{
    public override void Enter()
    {
        base.Enter();
        Debug.Log("InitPTS");
        this.PostNotification(Notifications.PLAYER_TURN_ENTER);
        StartCoroutine(Init());
    }

    IEnumerator Init()
    {
        Player.RefreshPawns();
        Player.UpdatePathfinding();
        var cinema = Camera.main.GetComponent<ProCamera2DCinematics>();
        foreach (Pawn pawn in Player.Pawns)
        {
            cinema.AddCinematicTarget(pawn.transform);
        }
        cinema.Play();
        foreach (Pawn pawn in Player.Pawns)
        {

            if (Enemy.IsPawnOnPoint(pawn.Engage))
                Enemy.GetPawnOnPoint(pawn.Engage).TakeDamage(pawn.Attack());
            cinema.GoToNextTarget();
            yield return new WaitForSeconds(1f);
        }
        cinema.Stop();
        
        while (cinema.CinematicTargets.Count != 0)
            cinema.RemoveCinematicTarget(cinema.CinematicTargets[0].TargetTransform);

        Owner.ChangeState<SelectPawnState>();
    }
}
