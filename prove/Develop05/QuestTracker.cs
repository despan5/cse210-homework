namespace Develope05;
using System.IO;
class QuestTracker
{
    private List<Goal> goals = new List<Goal>();
    private int level;
    private int score;
    

    public QuestTracker()
    {
        goals = new List<Goal>();
        score = 0;
        level = 1;
    }

    public void CreateGoal()
    {
        Console.WriteLine("Select the goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("Enter your choice:");

        string choice = Console.ReadLine();
        Goal goal;

        switch (choice)
        {
            case "1":
                goal = new SimpleGoal();
                break;
            case "2":
                goal = new EternalGoal();
                break;
            case "3":
                goal = new ChecklistGoal();
                break;
            default:
                Console.WriteLine("Invalid choice. Goal creation canceled.");
                return;
        }

        goal.CreateGoal();
        goals.Add(goal);
    }

    public void RecordEvent()
{
    Console.WriteLine("Enter the index of the goal you completed:");
    if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < goals.Count)
    {
        Goal goal = goals[index];
        goal.MarkComplete();

        score += goal.GetPoints();

        // Level up logic
        while (score >= level * 200)
        {
            level++;
        }

    }
    else
    {
        Console.WriteLine("Invalid goal index.");
    }
}

    public void DisplayGoals()
    {
        Console.WriteLine("Current Goals:");

        for (int i = 0; i < goals.Count; i++)
        {
            Goal goal = goals[i];
            string status = goal.IsCompleted ? "[X]" : "[ ]";
            Console.Write($"{status} {goal.Title} - {goal.Description}");

            if (goal is ChecklistGoal checklistGoal)
            {
                Console.Write($" (Completed {checklistGoal.CompletionCount}/{checklistGoal.TargetCount} times)");
            }

            Console.WriteLine();
        }
    }


    public void DisplayScore()
    {
        Console.WriteLine($"Your current level is: {level}");
        Console.WriteLine($"Your current score is: {score}");

        int nextLevelScore = level * 200;
        Console.WriteLine($"Next level at: {nextLevelScore} points");
    }


    public void SaveGoals(string fileName)
    {
        File.WriteAllText("goals.txt", String.Empty);
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine(level);
            writer.WriteLine(score);

            foreach (Goal goal in goals)
            {
                writer.WriteLine($"{goal.GetType().Name},{goal.Title},{goal.Description},{goal.GetPoints()},{goal.IsCompleted}");
            }
        }

        Console.WriteLine("Goals saved successfully!");
    }
    public void LoadGoals(string fileName)
    {
        if (File.Exists(fileName))
        {
            goals.Clear();

            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                level = int.Parse(reader.ReadLine());
                score = int.Parse(reader.ReadLine());

                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(',');

                    string goalType = data[0];
                    string title = data[1];
                    string description = data[2];
                    int points = int.Parse(data[3]);
                    bool isCompleted = bool.Parse(data[4]);

                    Goal goal;

                    switch (goalType)
                    {
                        case "SimpleGoal":
                            goal = new SimpleGoal();
                            break;
                        case "EternalGoal":
                            goal = new EternalGoal();
                            break;
                        case "ChecklistGoal":
                            goal = new ChecklistGoal();
                            break;
                        default:
                            // Skip invalid goal types
                            continue;
                    }

                    goal.Title = title;
                    goal.Description = description;
                    goal.SetCompletedStatus(isCompleted);

                    if (isCompleted)
                    {
                        goal.SetPoints(points);
                    }

                    goals.Add(goal);
                }
            }

            Console.WriteLine("Goals loaded successfully!");
        }
        else
        {
            Console.WriteLine("Goals file does not exist.");
        }
    }
}
