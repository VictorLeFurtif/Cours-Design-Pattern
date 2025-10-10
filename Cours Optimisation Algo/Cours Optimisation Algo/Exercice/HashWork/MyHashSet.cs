using System.Security.Principal;

namespace Cours_Optimisation_Algo.Exercice.HashWork;

public class MyHashSet
{

    //Init the grid so all indexCollision are set to -1
    public MyHashSet()
    {
        for (int i = 0; i < grid.Length; i++)
        {
            grid[i].indexCollision = -1;
        }
    }
    
    
    //tuple to stock and the word and the future index in case collision
    private (string? word, int indexCollision)[] grid = 
        new (string? word, int indexCollision)[59];

    //Method that will get us the index in our grid 
    private int Hash(string word)
    {
        int index = 0;
        
        foreach (char letter in word)
        {
            index = ((index * 31) + letter) % (grid.Length - 1);
        }
        
        return index;
    }


    private void SearchForFuturePlacement(int index, int i, string word)
    {
        while (grid[i].word != null)
        {
            i = (i + 1) % (grid.Length - 1);

            if (grid[i].word == null)
            {
                grid[i].word = word;
                grid[index].indexCollision = i;
                break;
            }
        }
    }
    
    
    //use hash to get and index and then check if index Collision is = -1 or stock it under when there is place
    private void Add(string word)
    {
        int index = Hash(word);

        if (grid[index].word == null) //so empty
        {
            grid[index].word = word;
        }
        
        else 
        {
            if (grid[index].indexCollision == -1) 
            {
                int i = index;
                SearchForFuturePlacement(index,i,word);
            }
            else 
            {
                int i = grid[index].indexCollision;
                
                while (grid[i].indexCollision != -1)
                {
                    i = grid[i].indexCollision;
                }

                index = i;
                SearchForFuturePlacement(index,i,word);
            }
        }
    }

    private bool IsInHashSet(string word)
    {
        int index = Hash(word);

        if (grid[index].word == word) return true;
        
        if (grid[index].indexCollision == -1) return false;
            
        //so there as been collision
            
        int i = grid[index].indexCollision;
            
        while (grid[i].indexCollision != -1)
        {
            if (grid[i].word == word)
            {
                return true;
            }

            i = grid[i].indexCollision;
        }
        return false;
    }
}