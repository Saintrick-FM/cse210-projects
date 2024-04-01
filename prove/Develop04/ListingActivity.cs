class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _count = 0;
        _prompts = new List<string> {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();
        DisplayGetReadyMessage();
        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);

        Console.WriteLine("You have a few seconds to start listing...");

        ShowSpinner(5); // Pause for 5 seconds

        // Simulate listing items
        int items = new Random().Next(1, 11); // Random number of items between 1 and 10
        Console.WriteLine($"You listed {items} items.");

        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        return _prompts[new Random().Next(_prompts.Count)];
    }

    public List<string> GetListFromUser()
    {
        List<string> list = new List<string>();
        Console.WriteLine("Enter items (press Enter after each item, type 'done' to finish):");
        string input = Console.ReadLine();
        while (input != "done")
        {
            list.Add(input);
            input = Console.ReadLine();
        }
        return list;
    }
}