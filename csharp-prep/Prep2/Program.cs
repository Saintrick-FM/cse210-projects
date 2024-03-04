using System;

class Program
{
    static void Main(string[] args)
    {
       // Ask the user for their grade percentage
        Console.WriteLine("Enter your grade percentage:");
        int gradePercentage = Convert.ToInt32(Console.ReadLine());

        // Determine the letter grade and pass/fail status
        string letter = "";
        string passStatus = "";

        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine pass/fail status
        if (gradePercentage >= 70)
        {
            passStatus = "Congratulations! You passed the course.";
        }
        else
        {
            passStatus = "Keep working hard for the next time.";
        }

        // Display the letter grade and pass/fail status
        Console.WriteLine($"Your letter grade is: {letter}");
        Console.WriteLine(passStatus);

        // Stretch Challenge: Determine the sign (+/-) for grades
        string sign = "";

        if (gradePercentage % 10 >= 7)
        {
            sign = "+";
        }
        else if (gradePercentage % 10 < 3)
        {
            sign = "-";
        }

        // Handle exceptional cases (A+, F+, F-)
        if (letter == "A" && sign == "+")
        {
            letter = "A";
            sign = "";
        }
        else if (letter == "F" && (sign == "+" || sign == "-"))
        {
            letter = "F";
            sign = "";
        }

        // Display the letter grade with sign
        Console.WriteLine($"Your final grade is: {letter}{sign}");
    }
}