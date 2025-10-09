namespace Cours_Optimisation_Algo.Exercice.Motus;


public class MotusGame
{

    #region Fields

    private string wordToGuess;

    private string answer;

    private bool won = false;

    private BinaryTree.BinaryTree tree;
    
    private List<string> listOfWordAvalaible = new List<string>(){
        "apple",
    };

    enum LetterState
    {
        Bad,
        Mid,
        Good
    }
    

    private List<LetterState> letterStates = new List<LetterState>();
    
    #endregion

    #region Main Region

    public void GameLoop()
    {
        InitTree();
        ChooseRandomWord();
        DisplayWordInit();
        InitLetterState();
        
        while (true)
        {
            TryToGuess();
            won = CheckIfWordCorrect();
            if (won)break;
        }
         
    }

    public MotusGame()
    {
        GameLoop();
    }

    #endregion

    #region Initialisation

    private void ChooseRandomWord()
    {
        Random random = new Random();
        wordToGuess = listOfWordAvalaible[random.Next(0, listOfWordAvalaible.Count)];
    }
    
    private void DisplayWordInit()
    {
        Console.Write(wordToGuess[0]);
        
        for (int i = 1; i < wordToGuess.Length ; i++)
        {
            Console.Write("_");
        }
        Console.WriteLine("");
    }

    private void InitLetterState() //we will Display in the future thanks to that
    {
        letterStates.Clear();
        
        for (int i = 0; i < wordToGuess.Length; i++)
        {
            letterStates.Add(LetterState.Bad);
        }

        letterStates[0] = LetterState.Good;
    }

    #endregion

    #region Methods Link To Motus

    private void TryToGuess()
    {
        while (true)
        {
            Console.Write($"Try to guess the word : {wordToGuess[0]}");
            answer = $"{wordToGuess[0]}{Console.ReadLine()}" ; //Here I order the player to always have the same first letter

            if (answer.Length > wordToGuess.Length)
            {
                Console.WriteLine($"Your word : {answer} have to much letter in it try again");
                continue;
            }
            
            if (answer.Length < wordToGuess.Length)
            {
                Console.WriteLine($"Your word : {answer} dont have enough letter in it try again");
                continue;
            }
            
            if (!WordEnterValid(answer))
            {
                Console.WriteLine($"Your word : {answer} dont exist try again");
                continue;
            }
            
            break;
            
        }
    }

    private bool CheckIfWordCorrect() //We will display the answer Here I suppose then give the opportunity to try again
    {
        InitLetterState();
        List<char> letterInTheWord = new List<char>();
        
        letterInTheWord.Clear();
        
        foreach (char letter in wordToGuess)
        {
            letterInTheWord.Add(letter);
        }
        
        if (wordToGuess.Length == answer.Length) //Check if at least both word are the same lenght
        {                                      
            for (int i = 0; i < wordToGuess.Length; i++)  // check first just good then recheck for the one that exist
            {
                if (wordToGuess[i] == answer[i])
                {
                    letterStates[i] = LetterState.Good;
                    letterInTheWord.Remove(answer[i]); 
                }
            }
            
            // Second verification

            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if (letterStates[i] == LetterState.Good) continue; //isnt correct

                foreach (var t in wordToGuess)
                {
                    if (answer[i] == t && letterInTheWord.Contains(answer[i])) // if it exist and isnt already used somewhere
                    {
                        letterStates[i] = LetterState.Mid;
                        letterInTheWord.Remove(answer[i]);
                    }
                }
            }
        }
        
        Display(letterStates);  //then we display
        
        if (wordToGuess == answer) // won
        {
            Console.WriteLine();
            Console.WriteLine($"Your word : {answer} is correct");
            return true;
        }
        Console.WriteLine(" ");
        return false;
    }

    private void Display(List<LetterState> _list)
    {
        for (int i = 0; i < wordToGuess.Length; i++)
        {
            switch (_list[i])
            {
                case LetterState.Bad:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LetterState.Mid:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LetterState.Good:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            Console.Write(answer[i]);
        }

        Console.ForegroundColor = ConsoleColor.White;
    }

    #endregion

    

    #region Methods Link To binary tree

    private void InitTree()
    {
        tree = new BinaryTree.BinaryTree();
        tree = tree.ExtractWord("C:\\Work\\Project 2025 2026\\DesignPattern_OptiAlgo_PathFinding\\Cours Optimisation Algo\\Cours Optimisation Algo\\Ressources\\liste.de.mots.francais.frgut.txt");
    }


    private bool WordEnterValid(string target)
    {
        return tree.Search(target);
    }
    #endregion
}