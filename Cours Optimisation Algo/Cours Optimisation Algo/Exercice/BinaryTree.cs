namespace Cours_Optimisation_Algo.Exercice;

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
        Console.WriteLine("The root is : " + rootNode.value);
        DisplayRecursive(rootNode);
    }

    private void DisplayRecursive(Node target)
    {
        if (target.leftReference != null)
        {
            Console.WriteLine("Enfant de gauche est : " + target.leftReference.value);
            DisplayRecursive(target.leftReference);
        }
        else
        {
            Console.WriteLine("Plus d'enfants");
        }

        if (target.rightReference != null)
        {
            Console.WriteLine("Enfant de droite est : " + target.rightReference.value);
            DisplayRecursive(target.rightReference);
        }
        else
        {
            Console.WriteLine("Plus d'enfants");
        }
    }

    public void Search(string content)
    {
        if (rootNode == null)
        {
            Console.WriteLine("Didnt Found the word : " + content);
            return;
        }
        
        Node target = new Node(content);
        rootNode.Search(target);
    }
}