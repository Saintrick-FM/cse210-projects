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

        DisplayPrompt(prompt);
        Console.Write("You may begin in: ");
        ShowCountDown(5); // Pause for 5 seconds

        List<string> userList = GetListFromUser();
        Console.WriteLine($"You listed {userList.Count()} items.");

        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        return _prompts[new Random().Next(_prompts.Count)];
    }
    public void DisplayPrompt(string prompt)
    {
        Console.WriteLine($"\nList as many responses you can to the following prompt:\n\n--- {prompt} ---");
    }


    public List<string> GetListFromUser()
    {
        List<string> list = new List<string>();
        string input;

        using (var timer = new System.Timers.Timer(_duration * 1000)) // Timer in milliseconds
        {
            timer.Elapsed += (sender, e) => timer.Stop(); // Stop timer after duration
            timer.Start();

            do
            {
                Console.Write("> ");
                input = Console.ReadLine();

                // Add input only if it's not empty
                if (!string.IsNullOrEmpty(input))
                {
                    list.Add(input);
                    _count++;
                }
            } while (timer.Enabled && input != null && input.Trim() != ""); // Exit on empty line or timer stop
        }

        return list;
    }
}