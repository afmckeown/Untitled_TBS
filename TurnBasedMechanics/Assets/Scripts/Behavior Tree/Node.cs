using UnityEngine;
using System.Collections;
using FullInspector;

namespace Behavior_Tree
{
    public abstract class Node : BaseBehavior
    {
        public abstract ActionResult Execute(AIPawn pawn);
    }

}
