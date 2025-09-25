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
            if (rightReference == null)
            {
                rightReference = target;
            }
            else
            {
                rightReference.Add(target);
            }
        }
        else
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
    }

    public void Search(Node target)
    {
        if (String.Compare(value,target.value) == 0) //Found it same value
        {
            Console.WriteLine("Found the word : " + value);
            return;
        }
        
        if (String.Compare(value,target.value) < 0)
        {
            if (rightReference == null)
            {
                Console.WriteLine("Didnt Found the word : " + target.value); 
                return;
            }
            else
            {
                rightReference.Search(target);
            }
        }
        else
        {
            
            if (leftReference == null)
            {
                Console.WriteLine("Didnt Found the word : " + target.value); 
                return;
            }
            else
            {
                leftReference.Search(target);
            }
        }
    }
}