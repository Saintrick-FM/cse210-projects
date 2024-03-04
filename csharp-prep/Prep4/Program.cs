using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        // Prompt the user to enter numbers until 0 is entered
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int input;
        do
        {
            Console.Write("Enter number: ");
            input = Convert.ToInt32(Console.ReadLine());

            if (input != 0)
            {
                numbers.Add(input);
            }

        } while (input != 0);

        // Core Requirements
        int sum = numbers.Sum();
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");
        int maxNumber = numbers.Max();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {maxNumber}");

        // Stretch Challenge
        List<int> positiveNumbers = numbers.Where(n => n > 0).ToList();
        int smallestPositiveNumber = positiveNumbers.Any() ? positiveNumbers.Min() : 0;

        Console.WriteLine($"The smallest positive number is: {smallestPositiveNumber}");

        // Sorting the list
        List<int> sortedList = numbers.OrderBy(n => n).ToList();

        Console.WriteLine("The sorted list is:");
        foreach (int number in sortedList)
        {
            Console.WriteLine(number);
        }
    }
}