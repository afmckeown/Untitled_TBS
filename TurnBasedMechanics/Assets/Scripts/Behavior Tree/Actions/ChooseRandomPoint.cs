using System.Collections.Generic;
using UnityEngine;

namespace Behavior_Tree.Actions
{
    public class ChooseRandomPoint : Action
    {
        public override ActionResult Execute(AIPawn pawn)
        {
            List<Point> points = pawn.BehaviorState.PointOptions;

            int rand = Random.Range(0, points.Count - 1);
            pawn.BehaviorState.PointChoice = points[rand];

            return ActionResult.Success;
        }
    }
}
