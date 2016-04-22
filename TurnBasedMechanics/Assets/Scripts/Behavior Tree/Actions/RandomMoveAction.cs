using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Behavior_Tree.Actions
{
    public class RandomMoveAction : Action
    {
        public override ActionResult Execute(AIPawn pawn)
        {
            List<Point> points = pawn.PointsInRange;

            int pointCount = points.Count;

            if (pointCount <= 0) return ActionResult.Failure;

            int rand = Random.Range(0, pointCount - 1);
            Point randPoint = points[rand];

            pawn.Move(randPoint);

            StartCoroutine(WaitForMoveToFinish(pawn));

            Debug.Log("RMA Move Coroutine Finished");

            return ActionResult.Success;
        }

        private IEnumerator WaitForMoveToFinish(Pawn pawn)
        {
            while (pawn.IsMoving)
                yield return null;
        }
    }

    
}
