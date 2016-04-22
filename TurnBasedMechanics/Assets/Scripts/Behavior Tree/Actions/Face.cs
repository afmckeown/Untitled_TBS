using UnityEngine;

namespace Behavior_Tree.Actions
{
    public class Face : Action
    {
        public override ActionResult Execute(AIPawn pawn)
        {
            pawn.Facing = pawn.BehaviorState.FacingSelection;

            return ActionResult.Success;
        }
    }
}
