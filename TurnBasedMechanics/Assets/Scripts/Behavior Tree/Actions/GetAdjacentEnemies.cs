using System.Collections.Generic;
using UnityEngine;

namespace Behavior_Tree.Actions
{
    public class GetAdjacentEnemies : Action
    {
        public override ActionResult Execute(AIPawn pawn)
        {
            BehaviorState behavior = pawn.BehaviorState;

            List<Point> adjacentPoints = pawn.Position.Adjacent();

            var adjacentPointsWithEnemy = new List<Point>();

            foreach (Point adjacentPoint in adjacentPoints)
            {
                if(BattleController.Instance.Player.IsPawnOnPoint(adjacentPoint))
                    adjacentPointsWithEnemy.Add(adjacentPoint);
            }

            behavior.PointOptions = adjacentPointsWithEnemy;

            if (behavior.PointOptions.Count <= 0) return ActionResult.Failure;

            return ActionResult.Success;
        }
    }
}
