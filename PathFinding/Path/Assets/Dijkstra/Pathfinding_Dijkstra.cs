using System.Collections.Generic;
using UnityEngine;


public class Pathfinding_Dijkstra : MonoBehaviour
{
    public static Pathfinding_Dijkstra Instance;

    double[,] graph;
    List<Transform> nodes = new List<Transform>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        graph = GetComponent<GraphManager>().GraphMatrix();
    }

    private (double[], int[]) Dijkstra(int start)
    {
        int n = graph.GetLength(0);
        double[] distances = new double[n];
        int[] predecessors = new int[n];
        List<int> visited = new List<int>();

        for (int i = 0; i < n; i++)
        {
            distances[i] = double.PositiveInfinity;
            predecessors[i] = -1;
        }

        distances[start] = 0;
        predecessors[start] = start;

        for (int i = 0; i < n; i++)
        {
            if (graph[start, i] != double.PositiveInfinity)
            {
                distances[i] = graph[start, i];
                predecessors[i] = start;
            }
        }

        visited.Add(start);

        while (visited.Count < n)
        {
            int current = -1;
            for (int i = 0; i < n; i++)
            {
                if (!visited.Contains(i) && distances[i] != double.PositiveInfinity)
                {
                    if (current == -1 || distances[i] < distances[current])
                        current = i;
                }
            }

            if (current == -1) break;

            for (int neighbor = 0; neighbor < n; neighbor++)
            {
                if (graph[current, neighbor] != double.PositiveInfinity && !visited.Contains(neighbor))
                {
                    double newDist = distances[current] + graph[current, neighbor];
                    if (newDist < distances[neighbor])
                    {
                        distances[neighbor] = newDist;
                        predecessors[neighbor] = current;
                    }
                }
            }

            visited.Add(current);
        }

        return (distances, predecessors);
    }

    private (double[], int[]) A_Star(int start, int end)
    {
        //variable init start
        int n = graph.GetLength(0);
        
        double[] l = new double[n];
        int[] predecessors = new int[n];
        
        double[] h = new double[n];
        List<int> o = new List<int>();
        List<int> c = new List<int>();
        
        List<int> visited = new List<int>();
        
        //variable init end
        
        //init A_Star start
        for (int i = 0; i < n; i++)
        {
            l[i] = double.PositiveInfinity;
            predecessors[i] = -1;
        }

        l[start] = 0;
        
        predecessors[start] = start;

        for (int i = 0; i < n; i++)
        {
            if (graph[start, i] != double.PositiveInfinity)
            {
                l[i] = graph[start, i];
                predecessors[i] = start;
            }
        }

        o.Add(start);
        
        for (int i = 0; i < n; i++)
        {
            if (graph[start, i] != double.PositiveInfinity)
            {
                h[i] = Vector3.Distance(nodes[i].transform.position, nodes[end].transform.position);
            }
        }
        
        //init A_Star end
        
        //logic A_Star start
        
        while (true)
        {
            int current = -1;

            foreach (int i in o)
            {
                if (current == -1 || l[current] + h[current] < l[i] + h[i])
                {
                    current = i;
                }
            }
            
            c.Add(current);
            o.Remove(current);
            
            if (current == end) break;

            for (int neighbors = 0; neighbors < n; neighbors++)
            {
                if (!double.IsPositiveInfinity(graph[current,neighbors]))
                {
                    if (o.Contains(neighbors))
                    {

                        if (l[neighbors] > l[current] + graph[current,neighbors])
                        {
                            l[neighbors] = l[current] + graph[current, neighbors];
                            predecessors[neighbors] = current;
                        }
                        
                    }

                    else if (c.Contains(neighbors))
                    {
                        if (l[neighbors] > l[current] + graph[current,neighbors])
                        {
                            l[neighbors] = l[current] + graph[current, neighbors];
                            predecessors[neighbors] = current;
                            c.Remove(neighbors);
                            o.Add(neighbors);
                        }
                    }
                    
                    else
                    {
                        l[neighbors] = l[current] + graph[current, neighbors];
                        predecessors[neighbors] = current;
                        o.Add(neighbors);
                    }
                }
            }
        }
        //logic A_Star end
        
        return (l, predecessors);
    }

    public List<Transform> GetPath(Transform startTransform, Transform endTransform, bool usingDijkstra)
    {
        nodes = GetComponent<GraphManager>().nodes;

        int start= nodes.IndexOf(startTransform);
        int end = nodes.IndexOf(endTransform);
        int[] predecessors = new int[] { };
        
        if (usingDijkstra)
        {
            var dijkstraResult = Dijkstra(start);
            predecessors = dijkstraResult.Item2;
        }
        else
        {
            var a_starResult = A_Star(start, end);
            predecessors = a_starResult.Item2;
        }

        List<Transform> path = new List<Transform>();
        int current = end;

        while (current != start)
        {
            path.Add(nodes[current]);
            current = predecessors[current];
        }
        path.Add(nodes[start]);
        path.Reverse();
        return path;
    }
}
