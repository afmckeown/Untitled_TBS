//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;

//public abstract class AbilityRange : MonoBehaviour 
//{
//	public int horizontal = 1;
//	public int vertical = int.MaxValue;
//	public virtual bool positionOriented { get { return true; }}
//	public virtual bool directionOriented { get { return false; }}
//	protected Pawn Pawn { get { return GetComponentInParent<Pawn>(); }}
	
//	public abstract List<Point> GetPointsInRange (Board board);
//}