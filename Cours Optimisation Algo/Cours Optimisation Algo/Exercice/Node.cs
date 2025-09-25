namespace Cours_Optimisation_Algo.Exercice;

public class Node
{
    public string value;
    public Node leftReference;
    public Node rightReference;

    public Node(string _value)
    {
        value = _value;
        leftReference = rightReference = null;
    }
    
    
    
    public void Add(Node target)
    {
        if (String.Compare(value,target.value) < 0)
        {
            if (leftReference == null)
            {
                leftReference = target;
            }
            else
            {
                leftReference.Add(target);
            }
        }
        else
        {
            if (rightReference == null)
            {
                rightReference = target;
            }
            else
            {
                rightReference.Add(target);
            }
        }
    }

    public void Search(Node target)
    {
        if (String.Compare(value,target.value) < 0)
        {
            if (leftReference == null)
            {
                Console.WriteLine("Not Found");
                return;
            }
            else
            {
                leftReference.Search(target);
            }
        }
        else
        {
            if (rightReference == null)
            {
                Console.WriteLine("Not Found");
                return;
            }
            else
            {
                rightReference.Search(target);
            }
        }
    }
}