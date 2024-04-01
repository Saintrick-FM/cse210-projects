class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        ShowCountDown(3);

        int countdown = _duration;
        while (countdown > 0)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(1000); // Pause for 1 second
            countdown--;

            Console.WriteLine("Breathe out...");
            Thread.Sleep(1000); // Pause for 1 second
            countdown--;
        }

        DisplayEndingMessage();
    }
}
