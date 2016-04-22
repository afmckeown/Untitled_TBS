using System;
using System.Collections.Generic;
using System.Net;

namespace Behavior_Tree
{
    public class Sequence : Composite
    {
       
        public override ActionResult Execute(AIPawn pawn)
        {
            Enter(pawn);
            while(Index < Children.Count)
            {
                ActionResult result = Children[Index].Execute(pawn);
                if (result != ActionResult.Success) return result;
                ++Index;
            }
            return ActionResult.Success;
        }


    }
}
