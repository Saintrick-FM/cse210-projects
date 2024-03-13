using System;

class Program
{
    static void Main(string[] args)
    {
       // Create a new job instance named job1
        Job job1 = new Job("Software Engineer", "XYZ Tech", 80000);

        // Set member variables for job1
        // Note: Direct access to private variables is used for simplicity in this example.
        // In a real-world scenario, it's advisable to use public properties (getters and setters).
        job1.JobTitle = "Senior Software Engineer";
        job1.Company = "ABC Solutions";
        job1.Salary = 100000;

        // Display company of job1
        Console.WriteLine($"Company for job1: {job1.Company}");

        // Create a second job instance
        Job job2 = new Job("Data Analyst", "Data Insights", 60000);

        // Set member variables for job2
        job2.JobTitle = "Senior Data Analyst";
        job2.Company = "Insights Data";
        job2.Salary = 80000;

        // Display company of job2
        Console.WriteLine($"Company for job2: {job2.Company}");
    }
}