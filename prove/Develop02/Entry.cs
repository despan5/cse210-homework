namespace Develope02;

    public class Entry
    {
        public string date = DateTime.Now.ToString();
        public string prompt = "";
        public string response = "";
        
        public void display(){
            Console.WriteLine(date);
            Console.WriteLine(prompt);
            Console.WriteLine(response);
        }
    }

