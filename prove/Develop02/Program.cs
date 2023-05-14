using Develope02;
using System.IO;
class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        Journal journal = new Journal();
        PromptGen promptGen = new PromptGen();
        int choice = 0;
        string fileName = "";
        int stop = 0;

        while (stop == 0)
        {
            choice = menu.Show();
            switch(choice)
            {
                case 1:
                   journal.AddEntry();
                   break;

                case 2:
                   journal.Display();
                   break;
                   
                case 3:
                   Console.Write("What is the file name of your journal? ");
                   fileName = Console.ReadLine();
                   journal.load(fileName);
                   break;

                case 4:
                   Console.Write("What is the file name of your journal? ");
                   fileName = Console.ReadLine();
                   //journal.save(entries, fileName);
                   break;

                case 5:
                    stop = 1;
                    break;
           }
        }
    }
}
