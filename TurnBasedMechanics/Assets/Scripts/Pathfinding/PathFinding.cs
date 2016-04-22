using System.Collections.Generic;
using Priority_Queue;

public static class PathFinding
{
    public static PathData Dijkstra(PathingGraph graph, Point source, int range)
    {
        var pathData = new PathData(source);

        var queue = new SimplePriorityQueue<Point>();

        queue.Enqueue(source, 0);
        pathData.DistanceFromSource.Add(source, 0);

        while (queue.Count != 0)
        {
            Point searchPoint = queue.Dequeue();

            List<Point> neighbors = graph.ConnectedNodes(searchPoint);

            foreach (Point neighbor in neighbors)
            {
                float totalCostToNext =
                    pathData.DistanceFromSource[searchPoint] +
                    graph.Cost(neighbor);
                if (totalCostToNext > range) continue;
                if (pathData.DistanceFromSource.ContainsKey(neighbor))
                {
                    if (pathData.DistanceFromSource[neighbor] > totalCostToNext)
                    {
                        if (queue.Contains(neighbor))
                        {
                            queue.UpdatePriority(neighbor, totalCostToNext);
                        }
                        else
                        {
                            queue.Enqueue(neighbor, totalCostToNext);
                        }

                        pathData.DistanceFromSource[neighbor] = totalCostToNext;
                        pathData.PreviousPoint[neighbor] = searchPoint;
                    }
                    continue;
                }
                queue.Enqueue(neighbor, totalCostToNext);
                pathData.DistanceFromSource.Add(neighbor, totalCostToNext);
                pathData.PreviousPoint.Add(neighbor, searchPoint);
            }
        }
        return pathData;
    }

}