using System.Collections;
using UnityEngine;

namespace Behavior_Tree.Actions
{
    public class Move : Action
    {
        // TODO: not dependent on Enemy
        public override ActionResult Execute(AIPawn pawn)
        {
           
            pawn.Move(pawn.BehaviorState.MoveSelection);
         
           
            return ActionResult.Success;
        }
    }
}
