namespace Develope04;

abstract class Activity
{
    public Random random = new Random();

    public string _name { get; protected set; }
    public string _description { get; protected set; }

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }
    public void StartActivity()
    {
        DisplaySpinner(2000);
        Console.Clear();
        Console.WriteLine($"\n*** {_name} ***");
        Console.WriteLine(_description);

        int duration = GetDuration();

        Console.WriteLine("Prepare to begin the activity...");
        Thread.Sleep(3000);
        Console.Clear();

        RunActivity(duration);

        Console.WriteLine($"Well done! You have completed the {_name.ToLower()} for {duration} seconds.");
        DisplaySpinner(5000);
    }

    protected abstract void RunActivity(int duration);

    protected int GetDuration()
    {
        int duration;
        while (true)
        {
            Console.Write("Enter the duration of the activity (in seconds): ");
            if (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
            {
                Console.WriteLine("Invalid duration. Please enter a positive integer value.");
            }
            else
            {
                break;
            }
        }
        return duration;
    }

    protected void DisplayAnimation(int duration)
    {
        int animationDelay = 1000;
        int animationLength = duration / animationDelay;

        for (int i = 0; i < animationLength; i++)
        {
            Console.Write(".");
            Thread.Sleep(animationDelay);
        }

        Console.WriteLine();
    }

    public void DisplaySpinner(int duration)
    {
        int spinnerDelay = 500;
        int spinnerLength = duration / spinnerDelay;

        for (int i = 0; i < spinnerLength; i++)
        {
            string[] spinnerFrames = { "/", "-", "\\", "|" };
            Console.Write(spinnerFrames[i % spinnerFrames.Length]);
            Thread.Sleep(spinnerDelay);
            Console.SetCursorPosition(0, Console.CursorTop);
            
        }
        ClearCurrentConsoleLine();
        Console.WriteLine();
    }
    public static void ClearCurrentConsoleLine()
    {
    int currentLineCursor = Console.CursorTop;
    Console.SetCursorPosition(0, Console.CursorTop);
    Console.Write(new string(' ', Console.WindowWidth)); 
    Console.SetCursorPosition(0, currentLineCursor);
    }
}