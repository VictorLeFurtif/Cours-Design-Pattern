namespace Cours_Optimisation_Algo.Exercice.BinaryTree;
using System.IO;
using System.Text;
public class BinaryTree
{
    private Node rootNode;
    
    public BinaryTree(Node target = null)
    {
        rootNode = target;
    }

    public void Add(Node target)
    {
        if (rootNode == null)
        {
            rootNode = target;
        }
        else
        {
            rootNode.Add(target);
        }
    }
    
    public void Display()
    {
        Console.WriteLine("The root is : " + rootNode.Value);
        DisplayRecursive(rootNode);
    }

    private void DisplayRecursive(Node target)
    {
        if (target.LeftReference != null)
        {
            Console.WriteLine("Enfant de gauche est : " + target.LeftReference.Value);
            DisplayRecursive(target.LeftReference);
        }
        else
        {
            Console.WriteLine("Plus d'enfants");
        }

        if (target.RightReference != null)
        {
            Console.WriteLine("Enfant de droite est : " + target.RightReference.Value);
            DisplayRecursive(target.RightReference);
        }
        else
        {
            Console.WriteLine("Plus d'enfants");
        }
    }

    public bool Search(string content)
    {
        bool found = false;
        
        if (rootNode == null)
        {
            return found;
        }
        
        Node target = new Node(content);
        
        found = rootNode.Search(target);
        return found;
    }

    public void Minimum()
    {
        if (rootNode == null)
        {
            Console.WriteLine("Didnt Found minimum because empty tree : ");
            return;
        }
        
        rootNode.Minimum();
    }
    
    public void Maximum()
    {
        if (rootNode == null)
        {
            Console.WriteLine("Didnt Found maximum because empty tree : ");
            return;
        }
        
        rootNode.Maximum();
    }
    
    public BinaryTree ExtractWord(string path)
    {
        string cheminFichier = path;
        
        Console.WriteLine("début du chargement du fichier et initialisation de l'arbre ...");
        
        string[] motsBruts = File.ReadAllLines(cheminFichier);
        
        string[] mots = new string[motsBruts.Length];
        
        for (int i = 0; i < mots.Length; i++)
        {
            string mot = motsBruts[i].Normalize(NormalizationForm.FormD);
            
            string motClean = "";
            
            foreach (char letter in mot)
            {
                if (letter >= 'a' && letter <= 'z')
                {
                    motClean += letter;
                }
            }
            
            mots[i] = motClean;
        }
        
        Random.Shared.Shuffle(mots);
        BinaryTree tree = new BinaryTree();
        
        foreach (var word in mots)
        {
            tree.Add(new Node(word));
        }

        return tree;
    }
}