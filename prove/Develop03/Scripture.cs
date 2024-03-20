using System;
using System.Collections.Generic;
using System.Linq;
class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    // Constructor
    public Scripture(Reference reference, string text)
    {

        _reference = reference;

        List<string> splitedText = text.Split(' ').ToList();
        List<Word> currentWords = new List<Word>();

        foreach (string singleWord in splitedText)
        {
            Word word = new Word(singleWord);
            currentWords.Add(word);
            _words = currentWords;
        }

    }

    // Method to hide a word at a specific index given
    public void HideRandomWords(int numberToHide)
    {
        _words[numberToHide].Hide();

    }

    
    public string GetDisplayText()
    {
        string visibleText = "";

        for (int i = 0; i < _words.Count; i++)
        {
            visibleText += _words[i].GetDisplayText() + ' ';
        }
        return visibleText;
    }

    public bool IsCompletlyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false; // If any word is not hidden, return false
            }
        }
        Console.Write("All words are hidden! ");
        return true; // All words are hidden, return true
    }

    //Property to get the list of words
    public List<Word> Words
    {
        get { return _words; }
    }
}
