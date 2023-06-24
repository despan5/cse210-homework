namespace Develope05;

class ChecklistGoal : Goal
{
    public int PointsPerCompletion { get; set; }
    public int BonusPoints { get; set; }
    public int TargetCount { get; set; }
    public int CompletionCount { get; private set; }
    public override void CreateGoal()
    {
        Console.WriteLine("Enter the goal title:");
        Title = Console.ReadLine();

        Console.WriteLine("Enter the goal description:");
        Description = Console.ReadLine();

        Console.WriteLine("Enter the points to award per completion:");
        if (int.TryParse(Console.ReadLine(), out int pointsPerCompletion))
        {
            PointsPerCompletion = pointsPerCompletion;
        }
        else
        {
            Console.WriteLine("Invalid points. Goal not created.");
            return;
        }

        Console.WriteLine("Enter the bonus points:");
        if (int.TryParse(Console.ReadLine(), out int bonusPoints))
        {
            BonusPoints = bonusPoints;
        }
        else
        {
            Console.WriteLine("Invalid bonus points. Goal not created.");
            return;
        }

        Console.WriteLine("Enter the target count:");
        if (int.TryParse(Console.ReadLine(), out int targetCount))
        {
            TargetCount = targetCount;
        }
        else
        {
            Console.WriteLine("Invalid target count. Goal not created.");
            return;
        }
    }

    public override void MarkComplete()
    {
        CompletionCount++;

        if (CompletionCount == TargetCount)
        {
            IsCompleted = true;
            Console.WriteLine($"Congratulations! You earned {BonusPoints} bonus points for completing the goal '{Title}'!");
        }
        else
        {
            Console.WriteLine($"You earned {PointsPerCompletion} points for completing the goal '{Title}'!");
        }
    }

    public override void DisplayGoalProgress()
    {
        string status = IsCompleted ? "[X]" : "[ ]";
        Console.WriteLine($"{status} {Title} - {Description} (Completed {CompletionCount}/{TargetCount} times)");
    }

    public override int GetPoints()
    {
        if (IsCompleted)
        {
            return BonusPoints;
        }
        else
        {
            return PointsPerCompletion;
        }
    }
    public override void SetCompletedStatus(bool isCompleted)
    {
        base.SetCompletedStatus(isCompleted);

        if (!isCompleted)
        {
            CompletionCount = 0;
        }
    }
}