namespace Develope04;
class Menu
{
    private Activity[] activities;

    public Menu()
    {
        activities = new Activity[]
        {
            new BreathingActivity(),
            new ReflectionActivity(),
            new ListingActivity()
        };
    }

    public void DisplayMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("\nPlease choose an activity:");
            for (int i = 0; i < activities.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {activities[i]._name}");
            }
            Console.WriteLine($"{activities.Length + 1}. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            if (int.TryParse(choice, out int activityIndex))
            {
                if (activityIndex >= 1 && activityIndex <= activities.Length)
                {
                    activities[activityIndex - 1].StartActivity();
                }
                else if (activityIndex == activities.Length + 1)
                {
                    Console.WriteLine("Exiting the program...");
                    Thread.Sleep(1000);
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}