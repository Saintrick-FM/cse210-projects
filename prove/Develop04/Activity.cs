using System;
using System.Collections.Generic;
using System.Threading;

// Base class for all activities
class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 50; // Duration initialized to 0, to be set later
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Starting {_name} activity: {_description}");
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"Good job! You have completed the {_name} activity.");
        Console.WriteLine($"Duration: {_duration} seconds");
    }

    public void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000); // Pause for 1 second
        }
        Console.WriteLine();
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000); // Pause for 1 second
        }
        Console.WriteLine();
    }
}
