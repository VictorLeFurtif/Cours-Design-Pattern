namespace Cours_Optimisation_Algo.Exercice.DynamicCode;

public class BagExercice
{
    #region Varialbe

    private int[,] stockValueArray;
    private List<ObjectSac> bag = new List<ObjectSac>()
    {
        new ObjectSac(3,50),
        new ObjectSac(10,100),
        new ObjectSac(5,20),
        new ObjectSac(1,5),
        new ObjectSac(8,80),
    };
    
    private int poids = 20;

    #endregion

    #region Bag Methods

    /// <summary>
    /// GET OPTIMAL CHOICE THE MORE YOU CAN TAKE IN YOUR BAG DEPENDING UPON THE VALUE
    /// </summary>
    /// <param name="n">INDEX OF THE BAG</param>
    /// <param name="p">YOUR CURRENT CAPACITY IN WEIGHT</param>
    /// <returns>BEST VALUE YOU CAN OBTAIN</returns>
    private int Sac(int n, int p)
    {
        if (n < 0) return 0;

        if (stockValueArray[n, p] > 0) return stockValueArray[n, p];
        
        if (bag[n].Poids > p)
        {
            stockValueArray[n,p] = Sac(n - 1, p);
            return stockValueArray[n, p];
        }
        
        stockValueArray[n,p] = int.Max(Sac(n - 1, p - bag[n].Poids) + bag[n].Valeur,Sac(n - 1, p));
        return stockValueArray[n, p];
    }

    public int SacGame()
    {
        stockValueArray = new int[bag.Count + 1, poids + 1];
        return Sac(bag.Count - 1, poids);
    }

    #endregion

}

/// <summary>
/// OBJECT CONTAIN BY BAG 
/// </summary>
public struct ObjectSac
{
    public int Poids;
    public int Valeur;

    public ObjectSac(int p, int v)
    {
        Poids = p;
        Valeur = v;
    }
}