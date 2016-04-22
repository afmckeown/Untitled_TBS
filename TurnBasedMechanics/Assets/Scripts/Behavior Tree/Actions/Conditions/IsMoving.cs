using UnityEngine;

namespace Behavior_Tree.Actions.Conditions
{
    public class IsMoving : Action
    {
        public override ActionResult Execute(AIPawn pawn)
        {
            return pawn.IsMoving ? 
                ActionResult.Success : 
                ActionResult.Failure;
        }
    }
}
