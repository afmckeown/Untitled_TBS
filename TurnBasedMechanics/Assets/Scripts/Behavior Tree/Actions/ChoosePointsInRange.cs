using System.Collections.Generic;
using UnityEngine;

namespace Behavior_Tree.Actions
{
    public class ChoosePointsInRange : Action {

       public override ActionResult Execute(AIPawn pawn)
       {
           var InRange = new List<Point>();

           foreach (Point point in pawn.BehaviorState.PointOptions)
           {
               if(pawn.PointsInRange.Contains(point))
                    InRange.Add(point);
           }

           pawn.BehaviorState.PointOptions = InRange;

           return pawn.BehaviorState.PointOptions.Count <= 0 ? 
                ActionResult.Failure : 
                ActionResult.Success;
       }
    }
}
