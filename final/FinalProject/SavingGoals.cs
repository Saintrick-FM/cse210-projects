public class SavingsGoal
{
    // Properties
    public string GoalName { get; set; }
    public double TargetAmount { get; set; }
    public double CurrentAmount { get; set; }

    // Constructor
    public SavingsGoal(string goalName, double targetAmount)
    {
        GoalName = goalName;
        TargetAmount = targetAmount;
        CurrentAmount = 0;
    }

    // Method to update current amount towards the goal
    public void UpdateCurrentAmount(double amount)
    {
        CurrentAmount += amount;
    }

    // Method to display savings goal details
    public void DisplayGoal()
    {
        Console.WriteLine($"Goal: {GoalName}");
        Console.WriteLine($"Target Amount: {TargetAmount}");
        Console.WriteLine($"Current Amount: {CurrentAmount}");
    }
}