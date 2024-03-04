using System;

class Program
{
    static void Main(string[] args)
    {
    Random random = new Random();
        bool playAgain = true;

        while (playAgain)
        {
            Console.WriteLine("Welcome to the Guess My Number game!");
            int magicNumber = random.Next(1, 101);

            // Initialize guess to a value outside the valid range
            int userGuess = 0;
            int guessCount = 0;

            // Loop until the user guesses the correct number
            while (userGuess != magicNumber)
            {
              
                Console.Write("What is your guess? ");
                userGuess = Convert.ToInt32(Console.ReadLine());
                guessCount++;

                // Check if the guess is higher, lower, or correct
                if (userGuess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (userGuess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it in {guessCount} guesses!");
                }
            }

            // Ask the user if they want to play again
            Console.WriteLine("Do you want to play again? (yes/no)");
            string playAgainInput = Console.ReadLine().ToLower();

            // Check if the user wants to play again
            playAgain = (playAgainInput == "yes");
        }

        Console.WriteLine("Thanks for playing!");
    }
}