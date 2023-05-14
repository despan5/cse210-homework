namespace Develope02;

    class Journal
    {
        PromptGen promptgen = new PromptGen();
        Entry entry = new Entry();
        public List<string> entries = new List<string>{
            ""
        };

        public void AddEntry() {
            entry.EntryValues();
            string userentry = Console.ReadLine();
            entries.Add(Date, prompt, userentry);
            entries.Add(userentry);
            
        }

        public void Display(){
            Console.WriteLine(entries);
        }

        public void load(string filename){
            
        }

        public void save(List<Entry> entries, string filename){
            System.IO.File.WriteAllLines(filename, entries.ToList());
            

        }
    }