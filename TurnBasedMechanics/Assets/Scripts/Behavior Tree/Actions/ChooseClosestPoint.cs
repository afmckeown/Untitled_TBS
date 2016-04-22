using System.Collections.Generic;
using UnityEngine;

namespace Behavior_Tree.Actions
{
    public class ChooseClosestPoint : Action
    {

        public override ActionResult Execute(AIPawn pawn)
        {
            List<Point> points = pawn.BehaviorState.PointOptions;

            if(points.Count <= 0) return ActionResult.Failure;

            Point closest = points[0];
            int shortestDistance = int.MaxValue;
            foreach (Point point in points)
            {
                int distance = point.Distance(pawn.Position);
                if (distance < shortestDistance)
                {
                    closest = point;
                    shortestDistance = distance;
                }
            }

            pawn.BehaviorState.PointChoice = closest;

            return ActionResult.Success;
        }
    }
}
