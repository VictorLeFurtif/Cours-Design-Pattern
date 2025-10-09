namespace Cours_Optimisation_Algo.Exercice.BinaryTree;

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
            Console.WriteLine("Didnt Found the word : " + content);
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
}