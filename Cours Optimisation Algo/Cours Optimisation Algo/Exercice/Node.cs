using System.Diagnostics.CodeAnalysis;

namespace Cours_Optimisation_Algo.Exercice;

public class Node
{
    public string Value;
    public Node LeftReference;
    public Node RightReference;

    public Node(string _value)
    {
        Value = _value;
        LeftReference = RightReference = null;
    }
    
    
    public void Add(Node target)
    {
        if (String.Compare(Value,target.Value) < 0)
        {
            if (RightReference == null)
            {
                RightReference = target;
            }
            else
            {
                RightReference.Add(target);
            }
        }
        else
        {
            
            if (LeftReference == null)
            {
                LeftReference = target;
            }
            else
            {
                LeftReference.Add(target);
            }
        }
    }
    
    public void Minimum()
    {
        if (LeftReference == null)
        {
            Console.WriteLine("The Minimum is : "+ Value);
            return;
        }
        LeftReference.Minimum();
    }
    
    public void Maximum()
    {
        if (RightReference == null)
        {
            Console.WriteLine("The Maximum is : "+ Value);
            return;
        }
        RightReference.Maximum();
    }
    

    public bool Search(Node target)
    {
        if (String.Compare(Value,target.Value) == 0) 
        {
            Console.WriteLine("Found the word : " + Value);
            return true;
        }
        
        else if (String.Compare(Value,target.Value) < 0)
        {
            if (RightReference == null)
            {
                Console.WriteLine("Didnt Found the word : " + target.Value); 
                return false;
            }
            else
            {
                RightReference.Search(target);
            }
        }
        else
        {
            
            if (LeftReference == null)
            {
                Console.WriteLine("Didnt Found the word : " + target.Value); 
                return false;
            }
            else
            {
                LeftReference.Search(target);
            }
        }

        return false;
    }
}