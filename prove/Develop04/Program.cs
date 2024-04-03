class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Menu options :");
            Console.WriteLine("1. Start Breathing activity");
            Console.WriteLine("2. Start Reflecting activity");
            Console.WriteLine("3. Start Listing activity");
            Console.WriteLine("4. Exit");
            Console.Write("Select a choice from the menu: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            BreathingActivity breathingActivity = new BreathingActivity();
            ReflectingActivity reflectingActivity = new ReflectingActivity();
            ListingActivity listingActivity = new ListingActivity();

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    breathingActivity.Run();
                    break;
                case 2:
                    Console.Clear();
                    reflectingActivity.Run();
                    break;
                case 3:
                    Console.Clear();
                    listingActivity.Run();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}