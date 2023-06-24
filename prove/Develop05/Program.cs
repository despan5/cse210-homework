using Develope05;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        QuestTracker questTracker = new QuestTracker();

        while (true)
        {
            Console.WriteLine("Eternal Quest Menu:");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Display Goals");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit");
            Console.WriteLine("Enter your choice:");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    questTracker.CreateGoal();
                    break;
                case "2":
                    questTracker.RecordEvent();
                    break;
                case "3":
                    questTracker.DisplayGoals();
                    break;
                case "4":
                    questTracker.DisplayScore();
                    break;
                case "5":
                    Console.WriteLine("Enter the file name: ");
                    string saveFileName = Console.ReadLine();
                    questTracker.SaveGoals(saveFileName);
                    break;
                case "6":
                    Console.WriteLine("Enter the file name: ");
                    string loadFileName = Console.ReadLine();
                    questTracker.LoadGoals(loadFileName);
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}