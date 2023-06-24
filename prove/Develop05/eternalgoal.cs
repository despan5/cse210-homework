namespace Develope05;

class EternalGoal : Goal
{
    public int Value { get; set; }

    public override void CreateGoal()
    {
        Console.WriteLine("Enter the goal title:");
        Title = Console.ReadLine();

        Console.WriteLine("Enter the goal description:");
        Description = Console.ReadLine();

        Console.WriteLine("Enter the goal value:");
        if (int.TryParse(Console.ReadLine(), out int value))
        {
            Value = value;
        }
        else
        {
            Console.WriteLine("Invalid value. Goal not created.");
        }
    }

    public override void MarkComplete()
    {
        // Add points for completing the goal
        Console.WriteLine($"Congratulations! You earned {Value} points for completing the goal '{Title}'!");
    }

    public override void DisplayGoalProgress()
    {
        string status = "[ ]";
        Console.WriteLine($"{status} {Title} - {Description}");
    }

    public override int GetPoints()
    {
        return Value;
    }
}