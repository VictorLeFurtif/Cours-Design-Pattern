
using Cours_Optimisation_Algo.Exercice;
using Cours_Optimisation_Algo.Exercice.Motus;

namespace Cours_Optimisation_Algo.Main;

internal class Program
{
    public static void Main(string[] args)
    {
        BinaryTree tree = new BinaryTree();
        tree.Add(new Node("coucou"));
        tree.Add(new Node("cours"));
        tree.Add(new Node("arara"));
        tree.Add(new Node("mmque"));
        tree.Display();
    }
}