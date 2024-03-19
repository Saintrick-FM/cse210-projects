using System;
using System.Collections.Generic;
using System.Linq;
class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    // private List<bool> _hiddenWords;

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
        _words.RemoveAt(numberToHide);
    }

    // Method to get the visible text of the scripture
    public string GetDisplayText()
    {
        Console.Clear();
        Console.WriteLine($"{_reference.ToString()}");

        string visibleText = "";
        if (_words.Count > 0)
        {
            for (int i = 0; i < _words.Count; i++)
            {

                visibleText += new string('_', _words[i].GetDisplayText().Length) + " ";

            }
            Console.WriteLine($" visibleText.Trim() = {visibleText.Trim()}");
            return visibleText.Trim();
        }
        else
        {
            return visibleText;
        }

    }

    public bool isCompletlyHidden()
    {
        if (_words.Count == 0)
        {
            Console.WriteLine("_words is empty.");
            return true;
        }
        else
        {
            Console.WriteLine("_words is not empty yet.");
            return false;
        }

    }

    //Property to get the list of words
    public List<Word> Words
    {
        get { return _words; }
    }
}
