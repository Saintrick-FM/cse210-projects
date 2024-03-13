public class Job
{
    public string _jobTitle; 
    public string _company;
    public int _startYear;
    public int _endYear;

    public double _salary;
//   public string List<Job> _jobs = new List<Job>();
    // Constructor
    public Job(string jobTitle, string company, double salary)
    {
        _jobTitle = jobTitle;
        _company = company;
        _salary = salary;
    }
  
     // New method to display job details
    public void DisplayJobDetails()
    {
        Console.WriteLine($"Job Title: {_jobTitle}");
        Console.WriteLine($"Company: {_company}");
        Console.WriteLine($"Salary: {_salary:C}"); // Format salary as currency
        Console.WriteLine(); // Add a blank line for separation
    }
    
}