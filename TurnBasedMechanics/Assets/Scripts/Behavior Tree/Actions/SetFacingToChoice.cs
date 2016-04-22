using UnityEngine;

namespace Behavior_Tree.Actions
{
    public class SetFacingToChoice : Action
    {
        public override ActionResult Execute(AIPawn pawn)
        {
            BehaviorState behavior = pawn.BehaviorState;

            if (behavior.PointChoice == null) return ActionResult.Failure;
            if(pawn.Position.Distance(behavior.PointChoice) != 1) return ActionResult.Failure;

            behavior.FacingSelection = pawn.Position.GetDirection(behavior.PointChoice);

            return ActionResult.Success;
        }
    }
}
