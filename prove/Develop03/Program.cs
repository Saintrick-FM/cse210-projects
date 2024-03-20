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

            // Check if availableIndices is empty before accessing it
            if (availableIndices.Count > 0 && userInput != "null")
            {
                int index = rand.Next(availableIndices.Count);
                int wordIndex = availableIndices[index];
                scripture.HideRandomWords(wordIndex);
                availableIndices.RemoveAt(index); // Remove the index from the list
            }
            Console.WriteLine($"{reference.GetDisplayText()} => {scripture.GetDisplayText()}");
            Console.WriteLine("\nPress Enter to continue or type 'quit' to finish:");
            userInput = Console.ReadLine().ToLower();
        }
        while (userInput != "quit" && scripture.IsCompletlyHidden() == false);
        
        Console.WriteLine("Program ended.");
    }

}


