class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private List<string> _availableQuestions;

    public ReflectingActivity() : base("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = new List<string> {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string> {
            "> Why was this experience meaningful to you?",
            "> Have you ever done anything like this before?",
            "> How did you get started?",
            "> How did you feel when it was complete?",
            "> What made this time different than other times when you were not as successful?",
            "> What is your favorite thing about this experience?",
            "> What could you learn from this experience that applies to other situations?",
            "> What did you learn about yourself through this experience?",
            "> How can you keep this experience in mind in the future?"
        };
        // Initialize _availableQuestions with the same questions as _questions
        _availableQuestions = new List<string>(_questions);
    }

    public void Run()
    {
        DisplayStartingMessage();
        DisplayGetReadyMessage();
        ShowSpinner(5);
        string prompt = GetRandomPrompt();

        DisplayPrompt(prompt);
        Console.WriteLine("When you have something in mind, Press Enter to continue...");
        string input = Console.ReadLine();

        if (string.IsNullOrEmpty(input))
        {
            Console.Write("Now ponder on each of the following questions as they related to this experience.\nYou may begin in: ");
            ShowCountDown(5);

            using (var timer = new System.Timers.Timer(_duration * 1000)) // Timer in milliseconds
            {
                timer.Elapsed += (sender, e) => timer.Stop(); // Stop timer after duration
                timer.Start();
                do
                {
                    string randomQuestion = GetRandomQuestion();
                    //Stop the activity if there is no more available question
                    if (randomQuestion == "")
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.Write(randomQuestion);
                        ShowSpinner(3);
                    }
                } while (timer.Enabled && _availableQuestions.Count > 0); // Exit on empty line or timer stop
            }
        }
        DisplayEndingMessage();

    }

    public string GetRandomPrompt()
    {
        return _prompts[new Random().Next(_prompts.Count)];
    }

    public string GetRandomQuestion()
    {
        if (_availableQuestions.Count == 0)
        {
            // If no more questions are available, return an empty string
            return "";
        }

        // Pick a random question from _availableQuestions
        int index = new Random().Next(_availableQuestions.Count);
        string randomQuestion = _availableQuestions[index];

        // Remove the question from _availableQuestions
        _availableQuestions.RemoveAt(index);

        return randomQuestion;
    }

    public void DisplayPrompt(string prompt)
    {
        Console.WriteLine($"\nConsider the following prompt:\n\n--- {prompt} ---\n");
    }

    public void DisplayQuestions()
    {
        foreach (string question in _questions)
        {
            Console.WriteLine(question);
            Thread.Sleep(2000); // Pause for 2 seconds
        }
    }

}