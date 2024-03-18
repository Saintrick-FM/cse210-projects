using System;
using System.Collections.Generic;
using System.Linq;
class Reference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int StartVerse { get; private set; }
    public int EndVerse { get; private set; }

    // Constructor for single verse reference
    public Reference(string reference)
    {
        string[] parts = reference.Split(':');
        if (parts.Length >= 2)
        {
            Book = parts[0];
            string[] verses = parts[1].Split('-');
            Chapter = int.Parse(verses[0]);
            if (verses.Length > 1)
            {
                EndVerse = int.Parse(verses[1]);
            }
            else
            {
                EndVerse = StartVerse;
            }
        }
        else
        {
            // Handle the case where the reference format is incorrect
            // For example, log an error or throw an exception
            Console.WriteLine("Error");
        }
    }
    // Constructor for verse range reference
    public Reference(string startReference, string endReference)
    {
        string[] startParts = startReference.Split(':');
        string[] endParts = endReference.Split(':');
        Book = startParts[0];
        Chapter = int.Parse(startParts[1].Split()[0]);
        StartVerse = int.Parse(startParts[1].Split()[1]);
        EndVerse = int.Parse(endParts[1].Split()[1]);
    }

    // Method to get the full reference string
    public string GetFullReference()
    {
        if (StartVerse == EndVerse)
        {
            return $"{Book} {Chapter}:{StartVerse}";
        }
        else
        {
            return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
        }
    }
}
