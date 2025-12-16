
using Cours_Optimisation_Algo.Exercice;
using Cours_Optimisation_Algo.Exercice.BinaryTree;
using Cours_Optimisation_Algo.Exercice.DynamicCode;
using Cours_Optimisation_Algo.Exercice.Motus;

namespace Cours_Optimisation_Algo.Main;

internal class Program
{
    public static void Main(string[] args)
    {
        BagExercice bagExercice = new BagExercice();
        Console.WriteLine(bagExercice.SacGame());  
    }
}