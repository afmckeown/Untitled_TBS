namespace Behavior_Tree.Actions
{
    public class SetMoveTargetToChoice : Action
    {

        public override ActionResult Execute(AIPawn pawn)
        {
            BehaviorState behavior = pawn.BehaviorState;

            if(behavior.PointChoice == null) return ActionResult.Failure;
            if(!pawn.PointsInRange.Contains(behavior.PointChoice)) return ActionResult.Failure;

            behavior.MoveSelection = behavior.PointChoice;

            return ActionResult.Success;

            
        }
    }
}
