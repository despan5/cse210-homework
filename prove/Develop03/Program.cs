//main program broken up into 2 classes for abstraction
//Things done to exceed requirements:
//increased the level of abstraction in the program by making methods that 
//make the code at the top here a lot more readable. I also added in more user 
//interface to introduce to the program and know that the program has ended.

using Develope03;
class Program
{
    static void Main(string[] args)
    {
        var program = new ScriptureMemorizationProgram();
        program.Run();
    }
}

class ScriptureMemorizationProgram
{
    private Scripture scripture;

    //main loop of the program that hides words by setting visibility
    public void Run()
    {
        Console.Clear();
        InitializeScripture();
        DisplayIntroduction();

        scripture.Display();
        Console.WriteLine("Press Enter to hide words or type 'quit' to exit:");
        string input = Console.ReadLine();

        while (!scripture.AllWordsHidden && !IsQuitCommand(input))
        {
            Console.Clear();
            int wordsToHideThisTime = GetRandomWordsToHide(scripture.WordsRemaining);
            scripture.SetVisibility(wordsToHideThisTime);

            if (!scripture.AllWordsHidden)
            {
                scripture.DisplayReference();
                scripture.Display();
                Console.WriteLine("Press Enter to hide words or type 'quit' to exit:");
                input = Console.ReadLine();
            }
        }

        DisplayExitMessage(input);
        Console.ReadLine();
    }

    //sets up the scripture and its reference
    private void InitializeScripture()
    {
        string text = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";
        Reference reference = new Reference("John", "3", "16");
        scripture = new Scripture(reference, text);
    }

    //introduction to the program
    private void DisplayIntroduction()
    {
        Console.WriteLine("This program is to help you memorize scriptures!");
        Console.WriteLine();
        scripture.DisplayReference();
    }

    //method to quit at any time
    private bool IsQuitCommand(string input)
    {
        return input.Equals("quit", StringComparison.OrdinalIgnoreCase);
    }

    //randomizes the words to hide
    private int GetRandomWordsToHide(int wordsRemaining)
    {
        Random random = new Random();
        return random.Next(1, Math.Min(4, wordsRemaining + 1));
    }
    
    //message for when the program ends depending on how
    private void DisplayExitMessage(string input)
    {
        if (IsQuitCommand(input))
        {
            Console.WriteLine("Program ended by the user.");
        }
        else
        {
            Console.WriteLine("Great job memorizing this scripture!");
        }
    }
}
