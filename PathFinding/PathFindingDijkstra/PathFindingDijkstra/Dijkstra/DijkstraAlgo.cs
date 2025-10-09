using System.Diagnostics;

namespace PathFindingDijkstra.Dijkstra;

public class DijkstraAlgo
{
    private List<int> M = new List<int>(); //start with S logic
    
    
    double[,] G =
    {
        { 0, 5, 3, 2, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity },
        { double.PositiveInfinity, 0, double.PositiveInfinity, double.PositiveInfinity, 2,2, double.PositiveInfinity, double.PositiveInfinity },
        { double.PositiveInfinity, 1, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity },
        {double.PositiveInfinity, double.PositiveInfinity,1,0, double.PositiveInfinity, 3, 2, double.PositiveInfinity },
        { double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, 0, 4, double.PositiveInfinity,7 },
        { double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity,4, double.PositiveInfinity },
        {double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, 1, double.PositiveInfinity,0,6},
        {double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, 0}
    };

    private int[] P = [-1,-1,-1,-1,-1,-1,-1,-1]; //S then alphabetic

    private List<int> V = [0, 1, 2, 3, 4, 5, 6, 7]; //all point

    private double[] L =
    [
        double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity,
        double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity
    ];

    private void InitDijKstra()
    {
        const int  s = 0;
        
        L[s] = 0;
        
        P[s] = s; 
        
        for (int x = 0; x < V.Count; x++)
        {
            
            if (G[s,x] < double.PositiveInfinity) 
            {
                L[x] = G[s, x];
                P[x] = s;
            }
            else
            {
                L[x] = double.PositiveInfinity;
                P[x] = -1;
            }
            
        }
        M.Add(s);
    }

    private void AlgoDijkstraTreatement()
    {
        while (M.Count != V.Count)
        {
            double valueRef = int.MaxValue;
            
            int x = 0;
            
            foreach (int summit in V)
            {
                if (!M.Contains(summit) && L[summit] < valueRef)
                {
                    valueRef = L[summit];
                    x = summit;
                }
            }
            

            for (int y = 0; y < V.Count; y++)
            {
                if (G[x,y] < double.PositiveInfinity && L[x] + G[x, y] < L[y]) 
                {
                    L[y] = L[x] + G[x, y];
                    P[y] = x;
                }
            }
            M.Add(x);
        }
        // need to return or display the M L AND P
        Display();
    }
    

    private void Display()
    {
        Console.WriteLine("Here is the M element : ");
        foreach (var i in M)
        {
            Console.Write(i + "; ");
        }
        
        Console.WriteLine();
        
        Console.WriteLine("Here is the L element : ");
        foreach (var i in L)
        {
            Console.Write(i + "; ");
        }
        
        Console.WriteLine();
        
        Console.WriteLine("Here is the P element : ");
        foreach (var i in P)
        {
            Console.Write(i + "; ");
        }
        
        Console.WriteLine();
        
        Console.WriteLine("Here is the V element : ");
        foreach (var i in V)
        {
            Console.Write(i + "; ");
        }
    }

    public void Dijkstra()
    {
        InitDijKstra();
        AlgoDijkstraTreatement();
    }

    public int GetElementFromPredecesor(int index)
    {
        return P[index];
    }
}