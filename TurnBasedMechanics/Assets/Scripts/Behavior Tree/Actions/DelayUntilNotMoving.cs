using UnityEngine;

namespace Behavior_Tree.Actions
{
    public class DelayUntilNotMoving : Action
    {
        public override ActionResult Execute(AIPawn pawn)
        {
            if (pawn.IsMoving == false)
            {
                Debug.Log("DUNM ISMOVING FALSE");
            }
            return pawn.IsMoving ? 
                ActionResult.Running : 
                ActionResult.Success;
        }
    }
}
