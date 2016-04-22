using UnityEngine;

namespace Behavior_Tree.Actions.Conditions
{
    public class HasMoveOptions : Action
    {
       public override ActionResult Execute(AIPawn pawn)
       {
            if(pawn.PointsInRange.Count > 0)
                if(pawn.HasEnoughAPToMove)
                    return ActionResult.Success;

            return ActionResult.Failure;
       }
    }
}
