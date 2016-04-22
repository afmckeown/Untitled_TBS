using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
//using UnityEngine;
//using System.IO;
//using System.Text;
//using YamlDotNet.Serialization;

//public class Tiled2UnityXmlToYaml2 : MonoBehaviour
//{
//    [SerializeField]
//    private string _path;
//    private const string NameOfBlockingLayer = "blocked";

//    public BoardData GetXmlData()
//    {
//        var blockingPoints = new List<Point>();

//        XElement root = XElement.Load(_path);

//        XElement Prefab = root.Element("Prefab");

//        int boardWidth = (int)Prefab.Attribute("numTilesWide");
//        int boardHeight = (int)Prefab.Attribute("numTilesHigh");

//        int tileWidth = (int)Prefab.Attribute("tileWidth");
//        int tileHeight = (int)Prefab.Attribute("tileHeight");

//        IEnumerable<XElement> layers = Prefab.Elements();

//        foreach (var layer in layers)
//        {
//            if ((string)layer.Attribute("name") != NameOfBlockingLayer)
//                continue;
//            var points = layer.Elements();

//            foreach (var point in points)
//            {
//                int x = (int)point.Attribute("x");
//                int y = (int)point.Attribute("y");

//                var TBC = XmlPointToPoint(x, y, boardHeight, tileHeight, tileWidth);

//                blockingPoints.Add(TBC);
//            }
//        }

//        return new BoardData
//        {
//            BoardHeight = boardHeight,
//            BoardWidth = boardWidth,
//            TileHeight = tileHeight,
//            TileWidth = tileWidth,
//            BlockingPoints = blockingPoints.ToArray()
//        };

//    }

//    public void ToYaml()
//    {
//        var boardData = GetXmlData();
//        var serializer = new Serializer();
//        var stringBuilder = new StringBuilder();

//        File.Delete("Test.txt");

//        var fileWriter = new StreamWriter("Test.txt");

//        var writer = new StringWriter(stringBuilder);

//        serializer.Serialize(writer, boardData);
//        serializer.Serialize(fileWriter, boardData);
//        Debug.Log(stringBuilder);

//        using (fileWriter)
//        {
//            fileWriter.WriteLine(writer);
//        }

//        fileWriter.Close();
//    }

//    public Point XmlPointToPoint(int x, int y, int boardHeight, int tileHeight, int tileWidth)
//    {

//        x = x / tileWidth;

//        y = (boardHeight - 1) - Mathf.Abs(y / tileHeight);

//        return new Point(x, y);
//    }
//}

//public class BoardData
//{
//    public int BoardWidth { get; set; }
//    public int BoardHeight { get; set; }

//    public int TileWidth { get; set; }
//    public int TileHeight { get; set; }

//    public Point[] BlockingPoints { get; set; }
//}
