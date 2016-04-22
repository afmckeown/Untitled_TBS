using UnityEngine;
using FullInspector;

namespace Behavior_Tree
{
    public class BehaviorTree : Node
    {
        public Node Child { get; private set; }
        
        public override ActionResult Execute(AIPawn pawn)
        {
            return Child.Execute(pawn);
        }
    }
}
