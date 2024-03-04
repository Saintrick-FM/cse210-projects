using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        Console.Write("What is your lane name? ");
        string lastName = Console.ReadLine();

        // Check if both inputs are entered
        if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
        {
            Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
        }
        else
        {
            Console.WriteLine("Please enter both values to log them.");
        }
    }
}