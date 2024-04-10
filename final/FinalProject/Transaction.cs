public class Transaction
{
    // Properties
    public int TransactionID { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public double Amount { get; set; }

    // Constructor
    public Transaction(int transactionID, DateTime date, string description, double amount)
    {
        TransactionID = transactionID;
        Date = date;
        Description = description;
        Amount = amount;
    }

    // Method to display transaction details
    public void DisplayTransaction()
    {
        Console.WriteLine($"Transaction ID: {TransactionID}");
        Console.WriteLine($"Date: {Date.ToShortDateString()}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Amount: {Amount}");
    }
}