using UnityEngine;
using System.Collections;

public class Node
{
    private const int DefaultCost = 1;

    public bool Connected { get; set; }

    public int Cost { get; set; }

    public Node()
    {
        Connected = true;
        Cost = DefaultCost;
    }

    public Node(bool connected)
    {
        Connected = connected;
        Cost = DefaultCost;
    }

    public Node(bool connected, int cost)
    {
        Connected = connected;
        Cost = cost;
    }
}
