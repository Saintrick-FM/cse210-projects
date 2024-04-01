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
        Console.WriteLine($"Welcome to the {_name} activity \n\n{_description}\n");

        try
        {
            Console.Write($"How long, in seconds, would you like for your session? ");
            string userInput = Console.ReadLine();
            _duration = int.Parse(userInput);

        }
        catch (FormatException)
        {
            // Handle the case when user input cannot be parsed to an integer
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }


    }
    public void DisplayGetReadyMessage()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
    }
    public void DisplayEndingMessage()
    {
        Console.WriteLine($"Good job! You have completed the {_name} activity.");
        ShowSpinner(5);
        Console.WriteLine($"Duration: {_duration} seconds");
        ShowSpinner(5);
        Console.Clear();
    }

    public void ShowSpinner(int seconds)
    {
        List<string> spinnerChars = new List<string> { "|", "/", "-", "\\" }; // Define spinner characters
        int index = 0;
        foreach (var item in spinnerChars)
        {
            Console.Write(spinnerChars[index]);
            index++;
            Thread.Sleep(200);
            Console.Write("\b \b");
        }
            Console.WriteLine("\n");

    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000); // Pause for 1 second
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }
}
