using UnityEngine;

namespace Behavior_Tree.Actions.Conditions
{
    public class IsEngagingEnemy : Action {

        public override ActionResult Execute(AIPawn pawn)
        {
            if(BattleController.Instance.Player.IsPawnOnPoint(pawn.Engage))
                return ActionResult.Success;

            return ActionResult.Failure;
        }
    }
}
