using System.Collections.Generic;
using UnityEngine;

namespace Behavior_Tree.Actions
{
    public class GetEnemyPointsInRange : Action
    {
        public override ActionResult Execute(AIPawn pawn)
        {
            Player player = BattleController.Instance.Player;

            var pointOptions = new List<Point>();

            List<Point> pointsInRange = pawn.PointsInRange;

            foreach (Point point in pointsInRange)
            {
                if(player.IsPawnOnPoint(point))
                    pointOptions.Add(point);
            }

            if(pointOptions.Count <= 0) return ActionResult.Failure;

            pawn.BehaviorState.PointOptions = pointOptions;

            return ActionResult.Success;
        }
    }
}
