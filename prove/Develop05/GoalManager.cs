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
        Console.WriteLine("The types of goals are:");
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GetStringRepresentation());
        }
    }

    public void CreateGoal(string name, string description, int points, GoalType type, int target = 0, int bonus = 0)
    {
        switch (type)
        {
            case GoalType.Simple:
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case GoalType.Eternal:
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case GoalType.Checklist:
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

    public void SaveGoals()
    {
        // string json = Newtonsoft.Json.JsonConvert.SerializeObject(_goals);
        // File.WriteAllText("_goals.json", json);
        // Console.WriteLine("Goals saved to file.");
    }
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.\n");
    }

    public void LoadGoals()
    {
        if (File.Exists("_goals.json"))
        {
            string json = File.ReadAllText("goals.json");
            // _goals = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Goal>>(json);
            Console.WriteLine("Goals loaded from file.");
        }
        else
        {
            Console.WriteLine("No saved goals found.");
        }
    }


    public GoalType ConvertToGoalType(string typeChoice)
    {
        switch (typeChoice)
        {
            case "1":
                return GoalType.Simple;
            case "2":
                return GoalType.Eternal;
            case "3":
                return GoalType.Checklist;
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

            // Goal simple = new Goal("Simple Goal", "This is just a simple goal", 300);
            // Goal eternal = new Goal("Eternal Goal", "This is just a simple goal", 1000);
            // Goal checklist = new Goal("CheckList Goal", "This is just a simple goal", 500);

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
                // case 3:
                //     Console.Clear();
                //     listingActivity.Run();
                //     break;
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

        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
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