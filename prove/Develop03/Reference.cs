using System;
using System.Collections.Generic;
using System.Linq;
class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = verse;

    }
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }


    public override string ToString()
    {
        return GetDisplayText();
    }
    // Method to get the full reference string
    public string GetDisplayText()
    {
        // Console.WriteLine($"Book = {_book} _chapter = {_chapter} verse = {_verse} endverse = {_endVerse}");
        if (_verse == _endVerse)
        {

            return $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }
}
