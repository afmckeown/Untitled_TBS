//using UnityEditor;
//using UnityEngine;

//[CustomEditor(typeof (GameBoard))]
//public class GameBoardBuilderEditor : Editor
//{
//    public override void OnInspectorGUI()
//    {
//        DrawDefaultInspector();

//        var myScript = (GameBoard) target;
//        if (GUILayout.Button("Construct"))
//        {
//            myScript.Start();
//        }
//        if (GUILayout.Button("Deconstruct"))
//        {
//            myScript.DestroyChildren();
//        }
//    }
//}