namespace Develope04;

class ListingActivity : Activity
{
    private List<string> prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };
    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }
    protected override void RunActivity(int duration)
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);
        DisplaySpinner(3000);

        Console.WriteLine("Get ready to list items...");
        Thread.Sleep(2000);

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        int itemCount = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("Enter an item: ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                itemCount++;
            }
        }

        Console.WriteLine($"\nYou listed {itemCount} items.");
    }

    private string GetRandomPrompt()
    {
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}