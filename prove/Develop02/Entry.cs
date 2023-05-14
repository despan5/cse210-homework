namespace Develope02;

    public class Entry
    {
        public void EntryValues(){
        DateTime date = DateTime.Now;
        PromptGen promptGen = new PromptGen();
        string prompt = promptGen.getPrompt();
        Console.WriteLine(prompt);
        
        }


    }