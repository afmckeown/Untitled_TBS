//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;

//public class ConstantAbilityRange : AbilityRange 
//{
//	public override List<Point> GetPointsInRange (Board board)
//	{
//		return board.Search(Pawn.tile, ExpandSearch);
//	}
	
//	bool ExpandSearch (Tile from, Tile to)
//	{
//		return (from.distance + 1) <= horizontal && Mathf.Abs(to.height - Pawn.tile.height) <= vertical;
//	}
//}