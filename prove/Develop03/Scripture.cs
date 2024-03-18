using System;
using System.Collections.Generic;
using System.Linq;
class Scripture
{
    public Reference Reference { get; private set; }
    private List<string> _words;
    private List<bool> _hiddenWords;

    // Constructor
    public Scripture(string reference, string text)
    {

        try
        {
            Reference = new Reference(reference);
            _words = text.Split(' ').ToList();
            _hiddenWords = Enumerable.Repeat(false, _words.Count).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating scripture: {ex.Message}");
            // Optionally, log the error or handle it as needed
        }

    }

    // Method to hide a word at a specific index
    public void HideWord(int index)
    {
        _hiddenWords[index] = true;
    }

    // Method to get the visible text of the scripture
    public string GetVisibleText()
    {
        string visibleText = "";
        for (int i = 0; i < _words.Count; i++)
        {
            if (_hiddenWords[i])
            {
                visibleText += new string('_', _words[i].Length) + " ";
            }
            else
            {
                visibleText += _words[i] + " ";
            }
        }
        return visibleText.Trim();
    }

    // Property to check if all words are hidden
    public bool AllWordsHidden
    {
        get { return _hiddenWords.All(h => h == true); }
    }

    // Property to get the list of words
    public List<string> Words
    {
        get { return _words; }
    }
}
