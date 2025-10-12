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
    
    private int count = 0;

    //Method that will get us the index in our grid FNV-1a a bit difficult
    private int Hash(string word)
    {
        const uint FNV_OFFSET_BASIS = 2166136261;
        const uint FNV_PRIME = 16777619; //golden number I think
    
        uint hash = FNV_OFFSET_BASIS;
    
        foreach (char c in word)
        {
            hash ^= c; //xor here
            hash *= FNV_PRIME; //scatter here
        }
    
        return (int)(hash % (uint)grid.Length);
    }


    private void SearchForFuturePlacement(int index, int i, string word)
    {
        int attempts = 0;
        
        while (grid[i].word != null)
        {
            if (attempts >= grid.Length)
            {
                throw new InvalidOperationException("HashSet is full! Cannot add more elements.");
            }
            
            i = (i + 1) % (grid.Length);
            attempts++;
            
            if (grid[i].word == null)
            {
                grid[i].word = word;
                grid[index].indexCollision = i;
                count++;
                break;
            }
        }
    }
    
    
    //use hash to get and index and then check if index Collision is = -1 or stock it under when there is place
    public void Add(string word)
    {
        if (count >= grid.Length)
        {
            throw new InvalidOperationException("HashSet is full! Cannot add more elements.");
        }   
        
        if (Contains(word)) return;
        
        int index = Hash(word);

        if (grid[index].word == null) //so empty
        {
            grid[index].word = word;
            count++;
            return;
        }
        
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

    public bool Contains(string word)
    {
        int index = Hash(word);

        if (grid[index].word == word) return true;
        
        if (grid[index].indexCollision == -1) return false;
            
        //so there as been collision
            
        int i = grid[index].indexCollision;
            
        while (grid[i].indexCollision != -1)
        {
            if (grid[i].word == word) return true;
            i = grid[i].indexCollision;
        }
        
        return grid[i].word == word;
    }
}