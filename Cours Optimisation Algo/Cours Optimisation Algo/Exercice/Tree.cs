namespace Cours_Optimisation_Algo.Exercice;

public class Tree
{
    private Node rootNode;

    public Tree(Node target = null)
    {
        rootNode = target;
    }

    public void Add(Node target, Node targetRoot = null)
    {
        if (rootNode == null) //if rootNode doesnt exist
        {
            rootNode = target;
        }
        
        else //TODO FIX ISSUE WITH COMPARE STRING
        {
            if (String.Compare(targetRoot.value,target.value) < 0 ) //left side
            {
                if (targetRoot.leftReference == null)
                {
                    targetRoot.leftReference = target;
                }
                else
                {
                    Add(target,targetRoot);
                }
            }
            else //right side
            {
                if (targetRoot.rightReference == null)
                {
                    targetRoot.rightReference = target;
                }
                else
                {
                    Add(target,targetRoot);
                }
            }
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
    
    public void Search(Node elementTarget,  Node targetRoot = null)
    {
        if (rootNode != null && elementTarget.value == rootNode.value) // first element
        {
            Console.WriteLine("Found it");
        }
        else
        {
            if (String.Compare(elementTarget.value, targetRoot.value) < 0)
            {
                
            }
        }
    }
    
}

