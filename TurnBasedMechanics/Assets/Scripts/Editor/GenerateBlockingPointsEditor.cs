using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TiledBlockingCellContainer))]
public class GenerateBlockingPointsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var myScript = (TiledBlockingCellContainer)target;
        if (GUILayout.Button("Import XML"))
        {
            myScript.GetXmlData();
        }
        if (GUILayout.Button("Generate Blocking Points"))
        {
            myScript.ToYaml();
        }
    }
}
