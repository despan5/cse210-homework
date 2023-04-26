using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGen = new Random();
        int magicNum = randomGen.Next(1, 101);

        int guess = -1;

        // We could also use a do-while loop here...
        while (guess != magicNum)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (magicNum > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNum < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }

        }                    
    }
}
