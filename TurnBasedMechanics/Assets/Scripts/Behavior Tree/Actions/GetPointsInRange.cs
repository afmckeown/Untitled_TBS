using UnityEngine;

namespace Behavior_Tree.Actions
{
    public class GetPointsInRange : Action
    {

        public override ActionResult Execute(AIPawn pawn)
        {
            pawn.BehaviorState.PointOptions = pawn.PointsInRange;

            if(pawn.BehaviorState.PointOptions == null)
                return ActionResult.Failure;
            if(pawn.BehaviorState.PointOptions.Count == 0)
                return  ActionResult.Failure;

            return ActionResult.Success;
        }
    }
}
