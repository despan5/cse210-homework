namespace Develope02;
using System.IO;

    class Journal
    {
        PromptGen promptgen = new PromptGen();
        List<Entry> entries = new List<Entry>();
        

        public void AddEntry() 
        {
            string prompt = promptgen.getPrompt();
            Console.WriteLine(prompt);
            string userentry = Console.ReadLine();
            Entry entry = new Entry();
            entry.date = DateTime.Now.ToString();
            entry.prompt = prompt;
            entry.response = userentry; 
            entries.Add(entry);
            
        }

        public void Display()
        {
            foreach (Entry entry in entries){
                entry.display();
            }
            
        }

        public void load(string file)
        {
            string filename = file;
            string[] lines = System.IO.File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                Entry entry = new Entry();
                string[] parts = line.Split("~");
                string date = parts[0];
                string prompt = parts[1];
                string response = parts[2];
                entry.date = date;
                entry.prompt = prompt;
                entry.response = response;
                entries.Add(entry);

            }
        }

        public void save(string file)
        {
            string fileName = file;

            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                foreach (Entry entry in entries)
                {
                    outputFile.WriteLine($"{entry.date}~{entry.prompt}~{entry.response}");
                }
            }

        }
    }
