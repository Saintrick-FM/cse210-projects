using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries;
    // public List<string> _prompts;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine($"{entry._date} - {entry._promptText} - {entry._entryText}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            // _entries.Clear();

            // using (StreamReader reader = new StreamReader(filename))
            // {
            //     while (!reader.EndOfStream)
            //     {
            //         string[] entryData = reader.ReadLine().Split(',');

            //         if (entryData.Length == 3)
            //         {
            //             Entry loadedEntry = new Entry(entryData[1], entryData[2], entryData[0]);
            //             _entries.Add(loadedEntry);
            //         }
            //     }
            // }
            _entries.Clear();
            string[] lines = System.IO.File.ReadAllLines(filename);
            if (lines.Length > 1)
            {
                foreach (string line in lines)
                {
                    string[] entriesData = line.Split("-");
                    Entry loadedEntry = new Entry(entriesData[0], entriesData[1], entriesData[2]);
                    _entries.Add(loadedEntry);
                    Journal journal = new Journal();
                    DisplayAll();
                }

            }
            else
            {
                Console.WriteLine("No entry found");
            }

        }
        else
        {
            Console.WriteLine("File not found. Please check the filename and try again.");
        }
    }
}
