class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void ListGoalNames()
    {
        Console.WriteLine("Goal Names:");
        foreach (Goal goal in _goals)
        {
            string goalName = goal.Name;
            Console.WriteLine($"{goalName}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        int count = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{count}. {goal.GetStringRepresentation()}");
            count++;
        }
    }

    public void CreateGoal(string name, string description, int points, GoalType type, int target = 0, int bonus = 0)
    {
        switch (type)
        {
            case GoalType.SimpleGoal:
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case GoalType.EternalGoal:
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case GoalType.ChecklistGoal:
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                throw new ArgumentException("Invalid goal type.");
        }
    }

    public void RecordEvent(string goalName)
    {
        Goal goal = _goals.Find(g => g.Name == goalName);
        if (goal != null)
        {
            goal.RecordEvent();
            _score += goal.Points;
        }
        else
        {
            Console.WriteLine("Goal not found.");
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine($"{_score}");
            foreach (var goal in _goals)
            {
                writer.WriteLine($"{goal.GetDetailsString()}");
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.\n");
    }

    // public void LoadGoals(string filename)
    // {
    //     if (File.Exists(filename))
    //     {

    //         string[] lines = System.IO.File.ReadAllLines(filename);
    //         if (lines.Length > 1)
    //         {
    //             foreach (string line in lines)
    //             {
    //                 string[] entriesData = line.Split("-");
    //                 Entry loadedEntry = new Entry(entriesData[0], entriesData[1], entriesData[2]);
    //                 _entries.Add(loadedEntry);
    //                 Journal journal = new Journal();
    //                 DisplayAll();
    //             }

    //         }
    //         else
    //         {
    //             Console.WriteLine("No entry found");
    //         }

    //     }
    //     else
    //     {
    //         Console.WriteLine("File not found. Please check the filename and try again.");
    //     }
    // }

    public GoalType ConvertToGoalType(string typeChoice)
    {
        switch (typeChoice)
        {
            case "1":
                return GoalType.SimpleGoal;
            case "2":
                return GoalType.EternalGoal;
            case "3":
                return GoalType.ChecklistGoal;
            default:
                throw new ArgumentException("Invalid goal type choice.");
        }
    }
    public void Start()
    {
        while (true)
        {
            DisplayPlayerInfo();
            Console.WriteLine("Menu options :");
            Console.WriteLine("  1. Create New Goal ");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    string goalChoosed = ChooseTypeOfGoal();
                    GoalCreation(goalChoosed);
                    break;
                case 2:
                    ListGoalDetails();
                    break;
                case 3:
                    Console.Write("What is the filename for the goal file? ");
                    string fileName = Console.ReadLine();
                    SaveGoals(fileName);
                    break;
                // case 4:
                //     Console.Clear();
                //     listingActivity.Run();
                //     break;
                // case 5:
                //     Environment.Exit(0);
                //     break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    public string ChooseTypeOfGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. SimpleGoal Goal");
        Console.WriteLine("  2. EternalGoal Goal");
        Console.WriteLine("  3. ChecklistGoal Goal");
        Console.Write("Which type of goal would you like to create? ");
        string typeChoice = Console.ReadLine();

        return typeChoice;
    }
    public void GoalCreation(string goalType)
    {
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is the short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        int target = 0;
        int bonusPoints = 0;

        if (goalType == "3")
        {
            Console.Write("Enter target: ");
            target = int.Parse(Console.ReadLine());
            Console.Write("Enter bonus points: ");
            bonusPoints = int.Parse(Console.ReadLine());
            CreateGoal(name, description, points, ConvertToGoalType(goalType), target, bonusPoints);
        }
        else
        {
            CreateGoal(name, description, points, ConvertToGoalType(goalType));
        }


    }
}