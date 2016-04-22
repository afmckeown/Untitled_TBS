using System.Collections.Generic;
using UnityEngine;

namespace Behavior_Tree.Actions
{
    public class GetPointsAdjacentToEnemies : Action
    {
        
        public override ActionResult Execute(AIPawn pawn)
        {
            var adjacentToEnemy = new List<Point>();
            foreach (Pawn enemy in BattleController.Instance.Player.Pawns)
            {
                List<Point> adjacent = enemy.Position.Adjacent();
                foreach (Point point in adjacent)
                {
                    if(!adjacentToEnemy.Contains(point))
                        adjacentToEnemy.Add(point);
                }
            }

            pawn.BehaviorState.PointOptions = adjacentToEnemy;

            return pawn.BehaviorState.PointOptions.Count <= 0 ?
                ActionResult.Failure : ActionResult.Success;
        }
    }
}
