using System.Collections.Generic;
using UnityEngine;
using YamlDotNet.Core.Tokens;

namespace Behavior_Tree
{
    public class Root : BehaviorTree
    {
        private Composite[] Composites { get; set; } 

        public override ActionResult Execute(AIPawn pawn)
        {
            if(!pawn.BehaviorState.IsBTRunning) Reset();
            //pawn.BehaviorState.IsBTRunning = true;

            var result = Child.Execute(pawn);

            pawn.BehaviorState.IsBTRunning = result == ActionResult.Running;

            if (pawn.BehaviorState.IsBTRunning == false)
            {
                Debug.Log("IsRunning FALSE");
            }

            return result;
        }

        public void Start()
        {
            Composites = GetComponentsInChildren<Composite>();
        }

        public void Reset()
        {
            foreach (Composite composite in Composites)
            {
                composite.Reset();
            }
        }
    }
}
