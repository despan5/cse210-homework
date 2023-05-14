namespace Develope02;
  
  public class Menu {  
    public int Show()

      {  
        Console.WriteLine("Please select an option:");  
        Console.WriteLine("1) Write");  
        Console.WriteLine("2) Display");  
        Console.WriteLine("3) Save");  
        Console.WriteLine("4) Load");  
        Console.WriteLine("5) Quit");
        string Choice = Console.ReadLine();
        int intchoice = Convert.ToInt32(Choice);

        return intchoice;
        

      }  
  }  
