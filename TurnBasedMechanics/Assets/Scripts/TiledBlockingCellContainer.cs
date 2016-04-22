using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using UnityEngine;
using System.IO;
using System.Text;
using YamlDotNet.Serialization;

public class TiledBlockingCellContainer : MonoBehaviour
{
    [SerializeField]
    private string _path;
    private const string NameOfBlockingLayer = "blocked";

    public BoardData GetXmlData()
    {
        Debug.Log("GetXMLData");
        var blockingPoints = new List<XY>();

        XElement root = XElement.Load(_path);

        XElement prefab = root.Element("Prefab");

        int boardWidth = (int)prefab.Attribute("numTilesWide");
        int boardHeight = (int)prefab.Attribute("numTilesHigh");

        int tileWidth = (int)prefab.Attribute("tileWidth");
        int tileHeight = (int)prefab.Attribute("tileHeight");

        IEnumerable<XElement> layers = prefab.Elements();

        foreach (var layer in layers)
        {
            if ((string)layer.Attribute("name") != NameOfBlockingLayer)
                continue;
            var elements = layer.Elements();

            foreach (var element in elements)
            {
                int x = (int)element.Attribute("x");
                int y = (int)element.Attribute("y");

                var TBC = XmlPointToXY(x, y, boardHeight, tileHeight, tileWidth);

                blockingPoints.Add(TBC);
            }
        }

        return new BoardData
        {
            BoardHeight = boardHeight,
            BoardWidth = boardWidth,
            TileHeight = tileHeight,
            TileWidth = tileWidth,
            BlockingPoints = blockingPoints.ToArray()
        };

    }

    public void ToYaml()
    {
        var boardData = GetXmlData();
        var serializer = new Serializer();
        //var stringBuilder = new StringBuilder();

        File.Delete("Test.txt");

        var fileWriter = new StreamWriter("Test.txt");

       // var writer = new StringWriter(stringBuilder);

        //serializer.Serialize(writer, boardData);
        serializer.Serialize(fileWriter, boardData);
        //Debug.Log(stringBuilder);

        //using (fileWriter)
        //{
        //    fileWriter.WriteLine(stringBuilder);
        //}

        fileWriter.Close();
    }

    public XY XmlPointToXY(int x, int y, int boardHeight, int tileHeight, int tileWidth)
    {

        x = x / tileWidth;

        y = (boardHeight - 1) - Mathf.Abs(y / tileHeight);

        return new XY(x, y);
    }
}

public class BoardData
{
    public int BoardWidth { get; set; }
    public int BoardHeight { get; set; }

    public int TileWidth { get; set; }
    public int TileHeight { get; set; }

    public XY[] BlockingPoints { get; set; }
}

public class XY
{
    public int X { get; set; }
    public int Y { get; set; }

    public XY(int x, int y)
    {
        X = x;
        Y = y;
    }

    public XY(){}
}
