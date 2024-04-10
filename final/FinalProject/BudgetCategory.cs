public class BudgetCategory
{
    // Properties
    public string CategoryName { get; set; }
    public double BudgetLimit { get; set; }
    public List<Transaction> Transactions { get; set; }

    // Constructor
    public BudgetCategory(string categoryName, double budgetLimit)
    {
        CategoryName = categoryName;
        BudgetLimit = budgetLimit;
        Transactions = new List<Transaction>();
    }

    // Method to add transaction to the category
    public void AddTransaction(Transaction transaction)
    {
        Transactions.Add(transaction);
    }

    // Method to display budget category details
    public void DisplayCategory()
    {
        Console.WriteLine($"Category: {CategoryName}");
        Console.WriteLine($"Budget Limit: {BudgetLimit}");
        Console.WriteLine($"Total Spent: {CalculateTotalSpent()}");
    }

    // Method to calculate total spent in the category
    public double CalculateTotalSpent()
    {
        double totalSpent = 0;
        foreach (var transaction in Transactions)
        {
            totalSpent += transaction.Amount;
        }
        return totalSpent;
    }
}
