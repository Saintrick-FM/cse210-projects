using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Create a new instance of the Scripture class
        List<Scripture> scriptureLibrary = new List<Scripture>();
        // Add scriptures to the library
        scriptureLibrary.Add(new Scripture("John 3:16", "For God so loved the world, he gaves his only begotten child so that anyone who will believe to him don't prish but get the eternal life"));
        scriptureLibrary.Add(new Scripture("Proverbs 3:5-6", "Trust in the Lord with all your heart..."));
        scriptureLibrary.Add(new Scripture("Jeremie 33,3", "Call me I will answer you, I will reveal you the hidden roads that you cannot see."));

        Random rand = new Random();
        Scripture selectedScripture = scriptureLibrary[rand.Next(scriptureLibrary.Count)];

        // Display the complete scripture
        DisplayScripture(selectedScripture);

        // Prompt the user to press enter or type quit
        Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
        string userInput = Console.ReadLine().ToLower();

        // Hide words in the scripture until all words are hidden or user types quit
        List<int> availableIndices = Enumerable.Range(0, selectedScripture.Words.Count).ToList();
        while (userInput != "quit" && !selectedScripture.AllWordsHidden)
        {
            HideRandomWord(selectedScripture, availableIndices);
            DisplayScripture(selectedScripture);
            Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
            userInput = Console.ReadLine().ToLower();
        }

        Console.WriteLine("Program ended.");
    }

    // Method to randomly hide a word in the scripture
    static void HideRandomWord(Scripture scripture, List<int> availableIndices)
    {
        Random rand = new Random();
        int index = rand.Next(availableIndices.Count);
        int wordIndex = availableIndices[index];
        availableIndices.RemoveAt(index); // Remove the index from the list
        scripture.HideWord(wordIndex);
    }

    // Method to display the complete scripture with hidden words
    static void DisplayScripture(Scripture scripture)
    {
        Console.Clear();
        Console.WriteLine($"Scripture: {scripture.Reference}");
        Console.WriteLine(scripture.GetVisibleText());
    }

}

// Class to represent a scripture reference

// Class to represent a scripture
