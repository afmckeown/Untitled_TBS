using System.Collections.Generic;
using UnityEngine;

namespace Behavior_Tree
{
    public abstract class Composite : Node
    {
        protected int Index { get; set; }

        [SerializeField]
        protected List<Node> Children { get; set; }

        public void Reset()
        {
            Index = 0;
        }

        public void Enter(AIPawn pawn)
        {
            if (pawn.BehaviorState.IsBTRunning == false)
                Index = 0;
        }
        
    }
}
