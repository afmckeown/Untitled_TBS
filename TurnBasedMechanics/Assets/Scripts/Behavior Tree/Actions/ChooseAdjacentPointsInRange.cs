using System.Collections.Generic;
using UnityEngine;

namespace Behavior_Tree.Actions
{
    public class ChooseAdjacentPointsInRange : Action
    {
        public override ActionResult Execute(AIPawn pawn)
        {
            List<Point> options = pawn.BehaviorState.PointOptions;

            var adjPointInRange = new List<Point>();

            foreach (Point point in options)
            {
                List<Point> adjacentPoints = point.Adjacent();

                foreach (Point adjacent in adjacentPoints)
                {
                    if (!pawn.PointsInRange.Contains(adjacent))
                        continue;
                    if(!adjPointInRange.Contains(adjacent))
                        adjPointInRange.Add(adjacent);
                }
            }

            pawn.BehaviorState.PointOptions = adjPointInRange;

            return pawn.BehaviorState.PointOptions.Count <= 0 ? 
                ActionResult.Failure : ActionResult.Success;
        }
    }
}
