using UnityEngine;

namespace Behavior_Tree
{
    public class Selector : Composite
    {
        public override ActionResult Execute(AIPawn pawn)
        {
            Enter(pawn);
            while (Index < Children.Count)
            {
                ActionResult result = Children[Index].Execute(pawn);
                if (result != ActionResult.Failure) return result;
                ++Index;
            }
            return ActionResult.Failure;
        }
    }
}
