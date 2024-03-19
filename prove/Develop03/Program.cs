using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Create a new instance of the Scripture class
        Reference reference = new Reference("1 John", 4, 20);
        Scripture selectedScripture = new Scripture(reference, "If someone says, “I love God,” and hates his brother, he is a liar; for the one who does not love his brother whom he has seen, cannot love God whom he has not seen.");

        selectedScripture.GetDisplayText();

        // Prompt the user to press enter or type quit
        Console.WriteLine("\nPress Enter to continue or type 'quit' to finish:");
        string userInput = Console.ReadLine().ToLower();

        //Hide words in the scripture until all words are hidden or user types quit
        List<int> availableIndices = Enumerable.Range(0, selectedScripture.Words.Count).ToList();

        while (userInput != "quit" && !selectedScripture.isCompletlyHidden())
        {
            // HideRandomWord(selectedScripture, availableIndices);
            Random rand = new Random();
            int index = rand.Next(availableIndices.Count);
            int wordIndex = availableIndices[index];
            availableIndices.RemoveAt(index); // Remove the index from the list

            selectedScripture.HideRandomWords(wordIndex);
            selectedScripture.GetDisplayText();

            Console.WriteLine("Press Enter to continue or type 'quit' to finish:");
            userInput = Console.ReadLine().ToLower();
        }

        Console.WriteLine("Program ended.");
    }

    // Method to randomly hide a word in the scripture
    // static void HideRandomWord(Scripture scripture, List<int> availableIndices)
    // {
    //     Random rand = new Random();
    //     int index = rand.Next(availableIndices.Count);
    //     int wordIndex = availableIndices[index];
    //     availableIndices.RemoveAt(index); // Remove the index from the list
    //     scripture.HideWord(wordIndex);
    // }

    // Method to display the complete scripture with hidden words
    // static void DisplayScripture(Scripture scripture)
    // {
    //     Console.Clear();
    //     Console.WriteLine($"Scripture: {scripture.Reference}");
    //     Console.WriteLine(scripture.GetVisibleText());
    // }

}


