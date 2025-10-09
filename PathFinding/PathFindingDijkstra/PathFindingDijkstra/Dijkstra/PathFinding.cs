namespace PathFindingDijkstra.Dijkstra;

public class PathFinding
{
    public void GetPath(int from, int to)
    {
        DijkstraAlgo dijkstra = new DijkstraAlgo();
        dijkstra.Dijkstra();
        
        int index = to;
        List<int> path = new List<int>();
        
        path.Add(to);

        while (true)
        {
            int newP = dijkstra.GetElementFromPredecesor(index - 1); 
            path.Add(newP);
            index = newP;
            
            if (newP == from)break;
        }

        path.Reverse();
        
        Console.WriteLine();
        
        Console.Write("Path  : ");
        foreach (var i in path)
        {
            Console.Write(i + "; ");
        }
    }
}