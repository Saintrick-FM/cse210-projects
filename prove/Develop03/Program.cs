using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("1 John", 4, 20);
        Scripture scripture = new Scripture(reference, "If someone says, “I love God,” and hates his brother, he is a liar; for the one who does not love his brother whom he has seen, cannot love God whom he has not seen.");

        List<int> availableIndices = Enumerable.Range(0, scripture.Words.Count).ToList();
        string userInput = "null";

        do
        {
            Console.Clear();
            Random rand = new();
            int initialNumberWordsToHide = 3;

            // Check if availableIndices is empty before accessing it
            if (availableIndices.Count > 0 && userInput != "null")
            {
                // Set the initial number of Words to hide to the HideMultipleRandomWords function, otherwise that initial number - 1
                int numberOfWordsToHide = availableIndices.Count >= initialNumberWordsToHide ? initialNumberWordsToHide : initialNumberWordsToHide - 1;
                HideMultipleRandomWords(scripture, availableIndices, numberOfWordsToHide);
            }

            Console.WriteLine($"{reference.GetDisplayText()}  {scripture.GetDisplayText()}");
            Console.WriteLine("\nPress Enter to continue or type 'quit' to finish:");
            userInput = Console.ReadLine().ToLower();
        }
        while (userInput != "quit" && !scripture.IsCompletelyHidden());

        Console.WriteLine("Program ended.");
    }

    // Method to randomly hide a specified number of words in the scripture
    static void HideMultipleRandomWords(Scripture scripture, List<int> availableIndices, int numberToHide)
    {
        Random rand = new Random();

        for (int i = 0; i < numberToHide; i++)
        {
            if (availableIndices.Count > 0)
            {
                int index = rand.Next(availableIndices.Count);
                int wordIndex = availableIndices[index];
                scripture.HideRandomWords(wordIndex);
                availableIndices.RemoveAt(index); // Remove the index from the list
            }
        }
    }

}

