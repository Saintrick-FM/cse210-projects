using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello FinalProject World!");
        Transaction transaction1 = new Transaction(1, DateTime.Now, "Grocery", 50.0);
        Transaction transaction2 = new Transaction(2, DateTime.Now, "Gas", 30.0);

        BudgetCategory foodCategory = new BudgetCategory("Food", 200.0);
        foodCategory.AddTransaction(transaction1);
        foodCategory.AddTransaction(transaction2);

        foodCategory.DisplayCategory();

        SavingsGoal vacationGoal = new SavingsGoal("Vacation", 1000.0);
        vacationGoal.UpdateCurrentAmount(500.0);

        vacationGoal.DisplayGoal();
    }
}