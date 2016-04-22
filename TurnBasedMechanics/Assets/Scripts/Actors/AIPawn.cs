using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BehaviorState))]
public class AIPawn : Pawn
{
    public BehaviorState BehaviorState { get; set; }
    
    protected new void Start()
    {
        base.Start();
        BehaviorState = GetComponent<BehaviorState>();
    }
}
