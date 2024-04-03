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

        using (var timer = new System.Timers.Timer(_duration * 1000)) // Timer in milliseconds
        {
            timer.Elapsed += (sender, e) => timer.Stop(); // Stop timer after duration
            timer.Start();
            do
            {
                Console.Write("Breathe in... ");
                ShowCountDown(4);
                countdown--;

                Console.Write("Breathe out... ");
                ShowCountDown(4);
                Console.WriteLine("\n");
                countdown--;

            } while (timer.Enabled); // Exit on empty line or timer stop
        }

        DisplayEndingMessage();
    }

}
