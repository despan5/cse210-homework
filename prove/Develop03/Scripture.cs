//class to do the main "meat" of the program including displaying,
//setting the visibility, and displaying the reference.
namespace Develope03;
    class Scripture
    {
        //attributes.
        private Random random = new Random();
        private Word[] words;
        private Reference reference;

        public bool AllWordsHidden => words.All(word => word.Hidden);
        public int WordsRemaining => words.Count(word => !word.Hidden);

        public Scripture(Reference reference, string text)
        {
            this.reference = reference;

            string[] wordStrings = text.Split(' ');
            words = new Word[wordStrings.Length];

            for (int i = 0; i < wordStrings.Length; i++)
            {
                words[i] = new Word(wordStrings[i]);
            }
        }

        //method to display the scripture with hidden words.
        public void Display()
        {
            foreach (Word word in words)
            {
                Console.Write(word.Hidden ? "_ " : word.Text + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        //method that sets random words to be hidden.
        public void SetVisibility(int count)
        {

            for (int i = 0; i < count; i++)
            {
                Word randomWord;
                do
                {
                    randomWord = words[random.Next(words.Length)];
                } while (randomWord.Hidden);

                randomWord.setIsVisible();
            }
        }

        //method to display the scripture reference.
        public void DisplayReference()
        {
            Console.WriteLine(reference.ToString());
        }
    }