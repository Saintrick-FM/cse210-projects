using System;
class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        DisplayGetReadyMessage();
        ShowSpinner(5);
        decimal rightDuration = _duration / 3;
        decimal countdown = Math.Round(rightDuration);

        do
        {
            Console.Write("Breathe in... ");
            ShowCountDown(4);
            countdown--;

            Console.Write("Breathe out... ");
            ShowCountDown(4);
            Console.WriteLine("\n");
            countdown--;
        }
        while (countdown > 0);
        DisplayEndingMessage();
    }

}
